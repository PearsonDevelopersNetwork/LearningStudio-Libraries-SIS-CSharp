#region License Information
// LearningStudio SIS API Libraries 
// These libraries make it easier to use the LearningStudio SIS APIs.
// Full Documentation is provided with the library. 
// 
// Need Help or Have Questions? 
// Please use the PDN Developer Community at https://community.pdn.pearson.com
//
// @category   LearningStudio SIS APIs
// @author     Jason Bradley <richard.bradley@pearson.com>
// @author     Pearson Developer Services Team <apisupport@pearson.com>
// @copyright  2015 Pearson Education Inc.
// @license    http://www.apache.org/licenses/LICENSE-2.0  Apache 2.0
// @version    1.0
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion License Information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using log4net;
using Com.Pearson.Pdn.Learningstudio.SIS.Utility;
using Com.Pearson.Pdn.Learningstudio.SIS.Users.Request;
using Com.Pearson.Pdn.Learningstudio.SIS.Users.WCFHelper;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Users
{
    /// <summary>
    /// UserService Class
    /// </summary>
    public class UserService
    {
        private API.UserManagementSoapClient userAPI;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UserService));
        private const string API_BINDING = "UserManagement";
        private const string INTERNAL_IDENTIFIER = "ECLG";
        private const string USER_API_XSD = "http://schemas.ecollege.com/Common/2006/01/ims_epv1p1.xsd";

        #region Public Methods

        /// <summary>
        /// Constructors a new UserService
        /// </summary>
        /// <param name="config"><s</param>
        public UserService(APIConfig config)
        {
            // Initiallize the User API and Overwrite the WCF generated SOAP Security Header with the values Required by the Service
            this.userAPI = new API.UserManagementSoapClient(API_BINDING);
            this.userAPI.Endpoint.EndpointBehaviors.Add(new InspectorBehavior(new ClientInspector(new SecurityHeader(config))));

            // Intiallize log4net
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Generates a ProcessSingle User API Request
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response ProcessSingleRequest(ProcessSingleRequest request)
        {
            API.enterprise enterprise = null;
            Response response = null;

            try
            {
                // Validate the SingleRequest Object prior to attempting the Request
                ValidateProcessSingleRequest(request);

                // Intialize Request
                enterprise = CreateEnterprise(request);
                
                // Build the Response object from the SOAP response
                response = ReadResponse(enterprise);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from ProcessSingleRequest: ", ex);
                throw;
            }
            finally
            {
                if (userAPI != null)
                    userAPI.Close();
            }

            return response;
        }

        #endregion

        #region Private Methods        

        /// <summary>
        /// Marshals and Creates the full XML payload for the User API Request
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <returns><see cref="API.enterprise"/>object</returns>
        private API.enterprise CreateEnterprise(ProcessSingleRequest request)
        {
            // Initialize and Set the Enterprise object and the core Child Elements
            API.enterprise enterprise = new API.enterprise();
            enterprise.properties = request.Properties;

            enterprise.person = new API.person[1];
            enterprise.person[0] = CreatePerson(request);

            // Handle User Property Only Update requests appropriately
            if (request.CallNumber != null || request.NodeString != null)
            {
                enterprise.group = new API.group[1];
                enterprise.group[0] = CreateGroup(request);

                enterprise.membership = new API.membership[1];
                enterprise.membership[0] = CreateMembership(request);
            }

            return enterprise;
        }

        /// <summary>
        /// Creates the Pearson child element for the User API Request
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <returns><see cref="API.person"/>object</returns>
        private static API.person CreatePerson(ProcessSingleRequest request)
        {
            // Initialize and Set the Person Element
            API.person person = new API.person();
            person.sourcedid = new API.sourcedid[1];
            person.sourcedid[0] = new API.sourcedid();
            person.sourcedid[0].source = request.Source;
            person.sourcedid[0].id = request.Id;
            person.sourcedid[0].sourcedidtypeSpecified = true;

            person.userid = new API.userid[1];
            person.userid[0] = new API.userid();
            person.userid[0].Value = request.LoginId;

            // If Password is used Set it
            if (request.Password != null)
                person.userid[0].password = request.Password;

            person.name = new API.name();
            person.name.n = new API.n();
            person.name.n.family = request.LastName;
            person.name.n.given = request.FirstName;
            
            // If Middle Name is used Set it
            if (request.MiddleName != null)
            {
                person.name.n.partname = new API.partname[1];
                person.name.n.partname[0] = new API.partname();
                person.name.n.partname[0].partnametype = "Middlename";
                person.name.n.partname[0].Value = request.MiddleName;
            }

            // If any Demographic values are used set them
            if (request.Gender != null || request.DOB != null || request.Disability != null)
            {
                person.demographics = new API.demographics();

                if (request.Gender != null)
                    person.demographics.gender = request.Gender;

                if (request.DOB != null)
                    person.demographics.bday = request.DOB;

                if (request.Disability != null)
                    person.demographics.disability = new string[1];
                    person.demographics.disability[0] = request.Disability;
            }

            person.email = request.Email;

            // If Phone Number is used set it
            if (request.PhoneNumber != null)
            {
                person.tel = new API.tel[1];
                person.tel[0] = new API.tel();
                person.tel[0].teltype = API.telTeltype.Voice;
                person.tel[0].Value = request.PhoneNumber;
            }

            // If any Address values are used set them
            if (request.Address1 != null || request.Address2 != null || request.City != null ||
                request.State != null || request.ZipCode != null || request.Country != null)
            {
                person.adr = new API.adr();

                if (request.Address1 != null && request.Address2 != null)
                    person.adr.street = new string[2];
                else if (request.Address1 != null || request.Address2 != null)
                    person.adr.street = new string[1];

                if (request.Address1 != null)
                    person.adr.street[0] = request.Address1;

                if (request.Address2 != null)
                {
                    if (request.Address1 != null)
                        person.adr.street[1] = request.Address2;
                    else
                        person.adr.street[0] = request.Address2;
                }

                if (request.City != null)
                    person.adr.locality = request.City;

                if (request.State != null)
                    person.adr.region = request.State;

                if (request.ZipCode != null)
                    person.adr.pcode = request.ZipCode;

                if (request.Country != null)
                    person.adr.country = request.Country;
            }

            // If any Extended User Properties are used Set them
            if (request.ExtendedUserProperties != null)
            {
                person.extension = new API.extension();
                person.extension.Any = new XmlElement[request.ExtendedUserProperties.Count];
                XmlDocument xml = new XmlDocument();
                int i = 0;
                
                foreach (string key in request.ExtendedUserProperties.Keys)
                {
                    XmlElement eup =  xml.CreateElement("personproperty");
                    eup.InnerText = request.ExtendedUserProperties[key];
                    XmlAttribute attr = xml.CreateAttribute("propertytype");
                    attr.Value = key;
                    eup.Attributes.Append(attr);

                    person.extension.Any[i] = eup;
                    i++;
                }

            }

            return person;
        }

        /// <summary>
        /// Creates the Group child element for the User API Request
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <returns><see cref="API.group"/>object</returns>
        private API.group CreateGroup(ProcessSingleRequest request)
        {
            // Initialize and Set the Group Element
            API.group group = new API.group();
            group.sourcedid = new API.sourcedid[1];
            group.sourcedid[0] = new API.sourcedid();

            // Set the SourcedId accordingly
            if (request.CallNumber != null)
            {
                group.sourcedid[0].source = request.Source;
                group.sourcedid[0].id = request.CallNumber;
            }
            else
            {
                group.sourcedid[0].source = INTERNAL_IDENTIFIER;
                group.sourcedid[0].id = request.NodeString;
            }

            group.grouptype = new API.grouptype[1];
            group.grouptype[0] = new API.grouptype();
            group.grouptype[0].typevalue = new API.typevalue[1];
            group.grouptype[0].typevalue[0] = new API.typevalue();
            group.grouptype[0].typevalue[0].level = "";

            // Setup either a Course Enrollment or Node Enrollment accordingly
            if (request.CallNumber != null)
                group.grouptype[0].typevalue[0].Value = "Call Number";
            else
                group.grouptype[0].typevalue[0].Value = "Enrollable Node";

            return group;
        }

        /// <summary>
        /// Creates the Membership child element for the User API Request
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <returns><see cref="API.membership"/>object</returns>
        private API.membership CreateMembership(ProcessSingleRequest request)
        {
            // Initialize and Set the Membership Element
            API.membership membership = new API.membership();
            membership.sourcedid = new API.sourcedid();

            // Set the SourcedId value accordingly
            if (request.CallNumber != null)
            {
                membership.sourcedid.source = request.Source;
                membership.sourcedid.id = request.CallNumber;
            }
            else
            {
                membership.sourcedid.source = INTERNAL_IDENTIFIER;
                membership.sourcedid.id = request.NodeString;
            }

            membership.member = new API.member[1];
            membership.member[0] = new API.member();
            membership.member[0].sourcedid = new API.sourcedid();
            membership.member[0].sourcedid.source = request.Source;
            membership.member[0].sourcedid.id = request.Id;

            membership.member[0].role = new API.role[1];
            membership.member[0].role[0] = new API.role();
            membership.member[0].role[0].subrole = request.RoleId;

            return membership;
        }

        /// <summary>
        /// Sends the ProcessSingleRequest request to the User API
        /// </summary>
        /// <param name="enterprise"><see cref="API.enterprise">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadResponse(API.enterprise enterprise)
        {
            Response response = new Response();
            try
            {
                enterprise = this.userAPI.ProcessSingleRequest(enterprise);

                
                XElement xe = XMLHelper.ParseXML<API.enterprise>(enterprise);
                XNamespace xsd = USER_API_XSD;

                response.Content = xe.ToString();
                response.ContentType = "text/xml";
                response.PersonStatusCode = GetPersonStatusCode(xe, xsd);
                response.PersonStatusMessage = GetPersonStatusMessage(xe, xsd);

                // Handle User Property Update Only requests appropriately
                if (enterprise.group != null || enterprise.membership != null)
                {
                    response.MembershipStatusCode = GetMembershipStatusCode(xe, response.PersonStatusCode, xsd);
                    response.MembershipStatusMessage = GetMembershipStatusMessage(xe, response.PersonStatusCode, xsd);
                }
                else
                {
                    response.MembershipStatusCode = 0;
                    response.MembershipStatusMessage = "This was a User Update Only request so there is no enrollment context.";
                }
            }
            catch (Exception ex)
            {
                response.Content = ex.Message;
                response.ContentType = "text/plain";
                response.PersonStatusCode = ex.HResult;
                response.PersonStatusMessage = "There was a System Exception! Check the Content from the Response for more details.";
                response.MembershipStatusCode = ex.HResult;
                response.MembershipStatusMessage = "There was a System Exception! Check the Conent from the Response for more details.";
            }

            return response;
        }

        /// <summary>
        /// Serializes the Person Status Code from the XML Response
        /// </summary>
        /// <param name="xe">The full XML Response</param>
        /// <param name="xsd">The Namespace of the IMS Enterprise XML schema</param>
        /// <returns>The Person Status Code</returns>
        private static int? GetPersonStatusCode(XElement xe, XNamespace xsd)
        {
            int? statusCode = null;

            // Parse the Status Code for the User from the Response
            IEnumerable <string> query = from xml in xe.Elements(xsd + "person").Elements(xsd + "extension").Elements("Result").Elements("Code")
                    select (string)xml;
            foreach (string s in query)
                statusCode = Convert.ToInt32(s);

            // If there wasn't a Status Code in the Response there was an issue
            if (statusCode == null)
                statusCode = -1;

            return statusCode;
        }

        /// <summary>
        /// Serializes the Person Status Message from the XML Response
        /// </summary>
        /// <param name="xe">The full XML Response</param>
        /// <param name="xsd">The Namespace of the IMS Enterprise XML schema</param>
        /// <returns>The Person Status Message</returns>
        private static string GetPersonStatusMessage(XElement xe, XNamespace xsd)
        {
            string statusMessage = null;

            // Parse the Status Message for the User from the Response
            IEnumerable<string> query = from xml in xe.Elements(xsd + "person").Elements(xsd + "extension").Elements("Result").Elements("Message")
                    select (string)xml;
            foreach (string s in query)
                statusMessage = s;

            // If there wasn't a Status Message in the Response there was an issue
            if (statusMessage == null)
                statusMessage = "There was an issue processing this request!!!";

            return statusMessage;
        }

        /// <summary>
        /// Serializes the Membership Status Code from the XML Response
        /// </summary>
        /// <param name="xe">The full XML Response</param>
        /// <param name="personStatusCode">The Person Status Code</param>
        /// <param name="xsd">The Namespace of the IMS Enterprise XML schema</param>
        /// <returns>The Membership Status Code</returns>
        private static int? GetMembershipStatusCode(XElement xe, int? personStatusCode, XNamespace xsd)
        {
            int? statusCode = null;

            // Parse the Status Code for the Enrollment from the Response
            IEnumerable<string> query = from xml in xe.Elements(xsd + "membership").Elements(xsd + "member").Elements(xsd + "role").Elements(xsd + "extension").Elements("Result").Elements("Code")
                    select (string)xml;
            foreach (string s in query)
                statusCode = Convert.ToInt32(s);

            // Duplicate Requsts are Implied Successful if the Person was successful
            // and there is no Result Object in the Member element of the Response
            if (statusCode == null)
            {
                if (personStatusCode >= 0)
                    statusCode = 0;
                else
                    statusCode = -1;
            }

            return statusCode;
        }

        /// <summary>
        /// Serializes the Membership Status Message from the XML Response
        /// </summary>
        /// <param name="xe">The full XML Response</param>
        /// <param name="personStatusCode">The Person Status Code</param>
        /// <param name="xsd">The Namespace of the IMS Enterprise XML schema</param>
        /// <returns>The Membership Status Message</returns>
        private static string GetMembershipStatusMessage(XElement xe, int? personStatusCode, XNamespace xsd)
        {
            string statusMessage = null;

            // Parse the Status Code for the Enrollment from the Response
            IEnumerable<string> query = from xml in xe.Elements(xsd + "membership").Elements(xsd + "member").Elements(xsd + "role").Elements(xsd + "extension").Elements("Result").Elements("Message")
                                        select (string)xml;
            foreach (string s in query)
                statusMessage = s;

            // Duplicate Requsts are Implied Successful if the Person was successful
            // and there is no Result Object in the Member element of the Response
            if (statusMessage == null)
            {
                if (personStatusCode >= 0)
                    statusMessage = "Course enrollment successful";
                else
                    statusMessage = "There was an issue processing this request!!!";
            }

            return statusMessage;
        }

        /// <summary>
        /// Performs validation and business logic checks on the ProcessSingleRequest values
        /// </summary>
        /// <param name="request"><see cref="ProcessSingleRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="ProcessSingleRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="ProcessSingleRequest">object</see></exception>
        private static void ValidateProcessSingleRequest(ProcessSingleRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.Source == null)
                throw new ArgumentNullException("The Source value is required.  Please correct and try the reqeust again.");
            else if (request.Id == null)
                throw new ArgumentNullException("The Id value is required.  Please correct and try the request again.");
            else if (request.LoginId == null)
                throw new ArgumentNullException("The LoginId value is required.  Please correct and try the request again.");
            else if (request.FirstName == null)
                throw new ArgumentNullException("The FirstName value is required.  Please correct and try the request again.");
            else if (request.LastName == null)
                throw new ArgumentNullException("The LastName value is required.  Please correct and try the request again.");
            else if (request.Email == null)
                throw new ArgumentNullException("The Email value is required.  Please correct and try the request again.");
            // Try to distinguish a Bad Enrollment Request from a User Property Update Only Request
            // The CallNumber and NodeString will be Null on a User Property Update Only Request but cannot on an Enrollment Request
            else if (request.CallNumber == null && request.NodeString == null && request.RoleId != null)
                throw new ArgumentNullException("Either a CallNumber or NodeString value is required.  Set the CallNumber value for a Course Enrollment " +
                    "or set the NodeString value for a Node Enrollment.  Please correct and try the request again");
            else if (request.CallNumber != null && request.NodeString != null)
                throw new ArgumentException("The CallNumber and NodeString values are mutually exclusive.  Only set the CallNumber value for a Course Enrollment " +
                    "or set the NodeString value for a Node Enrollment.  Please correct and try the request again");
        }

        #endregion
    }
}
