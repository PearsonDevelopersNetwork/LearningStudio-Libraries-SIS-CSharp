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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using log4net;
using Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request;
using Com.Pearson.Pdn.Learningstudio.SIS.Utility;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Terms
{
    /// <summary>
    /// TermService Class
    /// </summary>
    public class TermService
    {
        private API.EnterpriseTermServiceClient termAPI;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TermService));
        private const string API_BINDING = "CustomBinding_EnterpriseTermService";
        private const string ALL_NODES = "All";

        #region Public Methods

        /// <summary>
        /// Constructors a new TermService
        /// </summary>
        /// <param name="config"><s</param>
        public TermService(APIConfig config)
        {
            // Initiallize the Course API and Set the Username Token Credentials
            this.termAPI = new API.EnterpriseTermServiceClient(API_BINDING);
            this.termAPI.ClientCredentials.UserName.UserName = config.Username;
            this.termAPI.ClientCredentials.UserName.Password = config.Password;
            
            // Intiallize log4net
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Generates a CreateStandardTerm Term API Request
        /// </summary>
        /// <param name="request"><see cref="CreateStandardTermRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response CreateStandardTerm(CreateStandardTermRequest request)
        {
            API.StandardTermEx createTerm = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateCreateStandardTermRequest(request);

                // Intialize and Set the CopyCourseContentRequest
                createTerm = SetCreateStandardTermRequest(request);

                // Build the Response object from the SOAP response
                response = ReadCreateStandardTermResponse(createTerm);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from CreateStandardTerm: ", ex);
                throw;
            }
            finally
            {
                if (this.termAPI != null)
                    this.termAPI.Close();
            }

            return response;
        }

        /// <summary>
        /// Generates a UpdateStandardTerm Term API Request
        /// </summary>
        /// <param name="request"><see cref="UpdateStandardTermRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response UpdateStandardTerm(UpdateStandardTermRequest request)
        {
            API.StandardTermEx updateTerm = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateUpdateStandardTermRequest(request);

                // Intialize and Set the CopyCourseContentRequest
                updateTerm = SetUpdateStandardTermRequest(request);

                // Build the Response object from the SOAP response
                response = ReadUpdateStandardTermResponse(updateTerm);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from UpdateStandardTerm: ", ex);
                throw;
            }
            finally
            {
                if (this.termAPI != null)
                    this.termAPI.Close();
            }

            return response;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the XML payload for the CreateStandardTerm Term API Request
        /// </summary>
        /// <param name="request"><see cref="CreateStandardTermRequest">object</see></param>
        /// <returns><see cref="API.StandardTermEx"/>object</returns>
        private API.StandardTermEx SetCreateStandardTermRequest(CreateStandardTermRequest request)
        {
            // Initialize and Set the CreateStandardTermRequest
            API.StandardTermEx createTerm = new API.StandardTermEx();
            createTerm.ClientString = request.ClientString;
            createTerm.BillingClassificationType = request.BillingClassificationType.ToString();

            // Set the Nodes the Term will be tied to accordingly
            if (request.AssociatedEPOrganization != null)
                createTerm.AssociatedEPOrganization = request.AssociatedEPOrganization;
            else
                createTerm.AssociatedEPOrganization = new string[] { ALL_NODES };

            // Set the various Term timeframe properties
            createTerm.CourseActualTimeFrame = new API.TimeFrame();
            createTerm.CourseActualTimeFrame.StartDate = request.CourseActualStartDate;
            createTerm.CourseActualTimeFrame.EndDate = request.CourseActualEndDate;
            createTerm.DropAddPeriodTimeFrame = new API.TimeFrame();
            createTerm.DropAddPeriodTimeFrame.StartDate = request.DropAddPeriodStartDate;
            createTerm.DropAddPeriodTimeFrame.EndDate = request.DropAddPeriodEndDate;            
            createTerm.TermTimeFrame = new API.TimeFrame();
            createTerm.TermTimeFrame.StartDate = request.TermStartDate;
            createTerm.TermTimeFrame.EndDate = request.TermEndDate;

            if (request.RegistrationStartDate != null)
            {
                createTerm.RegistrationTimeFrame = new API.TimeFrame();
                createTerm.RegistrationTimeFrame.StartDate = request.RegistrationStartDate;
                createTerm.RegistrationTimeFrame.EndDate = request.RegistrationEndDate;
            }

            if (request.WithdrawPeriodEndsOn != null)
                createTerm.WithdrawPeriodEndsOn = request.WithdrawPeriodEndsOn;

            createTerm.Name = request.Name;
            createTerm.Description = request.Description;
            createTerm.TermTypeCode = API.TermType.Standard;            

            // Set the Destination Term Identifier
            createTerm.ID = new API.TermIdentifier();
            createTerm.ID.ID = request.TermSourcedId;
            createTerm.ID.MappingType = API.MappedTermIDType.SourcedID;

            return createTerm;
        }

        /// <summary>
        /// Creates the XML payload for the UpdateStandardTerm Term API Request
        /// </summary>
        /// <param name="request"><see cref="UpdateStandardTermRequest">object</see></param>
        /// <returns><see cref="API.StandardTermEx"/>object</returns>
        private API.StandardTermEx SetUpdateStandardTermRequest(UpdateStandardTermRequest request)
        {
            // Initialize and Set the UpdateStandardTermRequest
            API.StandardTermEx updateTerm = new API.StandardTermEx();
            updateTerm.ClientString = request.ClientString;
            updateTerm.BillingClassificationType = request.BillingClassificationType.ToString();
            updateTerm.Name = request.Name;
            updateTerm.TermTypeCode = API.TermType.Standard;
            
            // If specified update the Nodes the Term is associated with
            if (request.AssociatedEPOrganization != null)
                updateTerm.AssociatedEPOrganization = request.AssociatedEPOrganization;

            // If specified update the Course Dates
            if (request.CourseActualStartDate != null || request.CourseActualEndDate != null)
            {
                updateTerm.CourseActualTimeFrame = new API.TimeFrame();

                if (request.CourseActualStartDate != null)
                    updateTerm.CourseActualTimeFrame.StartDate = request.CourseActualStartDate;
                
                if (request.CourseActualEndDate != null)
                    updateTerm.CourseActualTimeFrame.EndDate = request.CourseActualEndDate;
            }

            // If specified update the Add Drop Dates
            if (request.DropAddPeriodStartDate != null || request.DropAddPeriodEndDate != null)
            {
                updateTerm.DropAddPeriodTimeFrame = new API.TimeFrame();

                if (request.DropAddPeriodStartDate != null)
                    updateTerm.DropAddPeriodTimeFrame.StartDate = request.DropAddPeriodStartDate;

                if (request.DropAddPeriodEndDate != null)
                    updateTerm.DropAddPeriodTimeFrame.EndDate = request.DropAddPeriodEndDate;
            }

            // If specified update the Term Dates
            if (request.TermStartDate != null || request.TermEndDate != null)
            {
                updateTerm.TermTimeFrame = new API.TimeFrame();
                
                if (request.TermStartDate != null)
                    updateTerm.TermTimeFrame.StartDate = request.TermStartDate;

                if (request.TermEndDate != null)
                    updateTerm.TermTimeFrame.EndDate = request.TermEndDate;
            }

            // If specified update the Registration Dates
            if (request.RegistrationStartDate != null || request.RegistrationEndDate != null)
            {
                updateTerm.RegistrationTimeFrame = new API.TimeFrame();

                if (request.RegistrationStartDate != null)
                    updateTerm.RegistrationTimeFrame.StartDate = request.RegistrationStartDate;

                if (request.RegistrationEndDate != null)
                    updateTerm.RegistrationTimeFrame.EndDate = request.RegistrationEndDate;
            }

            // If specified update the WithdrawPeriodEndsOn
            if (request.WithdrawPeriodEndsOn != null)
                updateTerm.WithdrawPeriodEndsOn = request.WithdrawPeriodEndsOn;            

            // If specified update the Description
            if (request.Description != null)
                updateTerm.Description = request.Description;            

            // Set the Term Identifier accordingly
            updateTerm.ID = new API.TermIdentifier();

            if (request.TermSourcedId != null)
            {                
                updateTerm.ID.ID = request.TermSourcedId;
                updateTerm.ID.MappingType = API.MappedTermIDType.SourcedID;
            }
            else
            {
                updateTerm.ID.ID = request.TermId;
                updateTerm.ID.MappingType = API.MappedTermIDType.TermID;
            }

            return updateTerm;
        }

        /// <summary>
        /// Sends the CreateStandardTerm request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.StandardTermEx">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadCreateStandardTermResponse(API.StandardTermEx request)
        {
            Response response = new Response();
            API.TermIdentifier createTermStatus = new API.TermIdentifier();

            try
            {
                createTermStatus = this.termAPI.CreateStandardTerm(request);

                XElement xe = XMLHelper.ParseXML<API.TermIdentifier>(createTermStatus);
                response.Content = xe.ToString();
                response.ContentType = "text/xml";

                // Handle the Response Status accordingly
                if (createTermStatus.ID != null)
                {
                    response.StatusCode = "Ok";
                    response.StatusMessage = String.Format("Term creation successful!  TermId: {0}", createTermStatus.ID);
                }
                else
                {
                    response.StatusCode = "Failure";
                    response.StatusMessage = "CreateStandardTermRequest Failed.";
                }
            }
            catch (FaultException ex)
            {
                // Serialize the Fault details
                MessageFault detail = ex.CreateMessageFault();
                XElement fault = detail.GetDetail<XElement>();

                response.Content = fault.ToString();
                response.ContentType = "text/xml";
                response.StatusCode = fault.Name.LocalName;
                response.StatusMessage = String.Format("{0}: {1}", fault.Name.LocalName, fault.Value);
            }
            catch (Exception ex)
            {
                response.Content = ex.Message;
                response.ContentType = "text/plain";
                response.StatusCode = ex.HResult.ToString();
                response.StatusMessage = "There was a System Exception! Check the Content from the Response for more details.";
            }

            return response;
        }

        /// <summary>
        /// Sends the UpdateStandardTerm request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.StandardTermEx">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadUpdateStandardTermResponse(API.StandardTermEx request)
        {
            Response response = new Response();
            API.TermIdentifier updateTermStatus = new API.TermIdentifier();

            try
            {
                updateTermStatus = this.termAPI.UpdateStandardTerm(request);

                XElement xe = XMLHelper.ParseXML<API.TermIdentifier>(updateTermStatus);
                response.Content = xe.ToString();
                response.ContentType = "text/xml";

                // Handle the Response Status accordingly
                if (updateTermStatus.ID != null)
                {
                    response.StatusCode = "Ok";
                    response.StatusMessage = String.Format("Term creation successful!  TermId: {0}", updateTermStatus.ID);
                }
                else
                {
                    response.StatusCode = "Failure";
                    response.StatusMessage = "UpdateStandardTermRequest Failed.";
                }
            }
            catch (FaultException ex)
            {
                // Serialize the Fault details
                MessageFault detail = ex.CreateMessageFault();
                XElement fault = detail.GetDetail<XElement>();

                response.Content = fault.ToString();
                response.ContentType = "text/xml";
                response.StatusCode = fault.Name.LocalName;
                response.StatusMessage = String.Format("{0}: {1}", fault.Name.LocalName, fault.Value);
            }
            catch (Exception ex)
            {
                response.Content = ex.Message;
                response.ContentType = "text/plain";
                response.StatusCode = ex.HResult.ToString();
                response.StatusMessage = "There was a System Exception! Check the Content from the Response for more details.";
            }

            return response;
        }

        /// <summary>
        /// Performs validation and business logic checks on the CreateStandardTermRequest values
        /// </summary>
        /// <param name="request"><see cref="CreateStandardTermRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="CreateStandardTermRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="CreateStandardTermRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="CreateStandardTermRequest">object</see> is invalid.</exception>
        private static void ValidateCreateStandardTermRequest(CreateStandardTermRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.CourseActualStartDate == null || request.CourseActualStartDate == DateTime.MinValue)
                throw new ArgumentNullException("The CourseActualStartDate value is required.  Please correct and try the request again.");
            else if (request.CourseActualEndDate == null  || request.CourseActualEndDate == DateTime.MinValue)
                throw new ArgumentNullException("The CourseActualEndDate value is required.  Please correct and try the request again.");
            else if (request.DropAddPeriodStartDate == null || request.DropAddPeriodStartDate == DateTime.MinValue)
                throw new ArgumentNullException("The DropAddPeriodStartDate value is required.  Please correct and try the request again.");
            else if (request.DropAddPeriodEndDate == null  || request.DropAddPeriodEndDate == DateTime.MinValue)
                throw new ArgumentNullException("The DropAddPeriodEndDate value is required.  Please correct and try the request again");
            else if (request.TermSourcedId == null)
                throw new ArgumentNullException("The TermSourcedId values is required.  Please correct and try the request again");
            else if (request.Name == null)
                throw new ArgumentNullException("The Name value is required.  Please correct and try the request again.");
            else if (request.TermStartDate == null || request.TermStartDate == DateTime.MinValue)
                throw new ArgumentNullException("The TermStartDate value is required.  Please correct and try the request again.");
            else if (request.TermEndDate == null || request.TermEndDate == DateTime.MinValue)
                throw new ArgumentNullException("The TermEndDate value is required.  Please correct and try the request again.");
            else if (request.DropAddPeriodStartDate == request.CourseActualStartDate)
                throw new ArgumentException("The DropAddPeriodStartDate value is set to the CourseActualStartDate.  This could cause downstream integration issues with the LearningStudio Enrollment API.  " +
                    "Best practice is to set the DropAddPeriodEndDate = CourseActualEndDate and set the DropAddPeriodStartDate = (CourseActualEndDate - 1 Day).  Please correct and try the request again.");
            else if (request.CourseActualEndDate <= request.CourseActualStartDate)
                throw new ArgumentOutOfRangeException("The CourseActualStartDate must be before the CourseActualEndDate.  Please correct and try the request again.");
            else if (request.DropAddPeriodEndDate <= request.DropAddPeriodStartDate)
                throw new ArgumentOutOfRangeException("The DropAddPeriodStartDate must be before the DropAddPeriodEndDate.  Best practice is to set the DropAddPeriodEndDate = CourseActualEndDate and set the " +
                    "DropAddPeriodStartDate = (CourseActualEndDate - 1 Day).  Please correct and try the request again.");
            else if (request.TermEndDate <= request.TermStartDate)
                throw new ArgumentOutOfRangeException("The TermStartDate must be before the TermEndDate.  Please correct and try the request again.");
            else if (!request.TermSourcedId.Contains(":"))
                throw new ArgumentOutOfRangeException("The TermSourcedId should have a format of \"{Source}:{Id}\".  Note the colon delimiter that seperates the two concatenated values.  " +
                    "In addition, please use your ClientString as the {Source} portion of this concatenated value.  Please correct and try the request again.");
            else if (request.RegistrationEndDate != DateTime.MinValue && request.RegistrationStartDate != DateTime.MinValue) 
            {
                if (request.RegistrationEndDate <= request.RegistrationStartDate)
                    throw new ArgumentOutOfRangeException("The RegistrationStartDate must be before the RegistrationEndDate.  Please correct and try the request again.");
            }
        }

        /// <summary>
        /// Performs validation and business logic checks on the UpdateStandardTermRequest values
        /// </summary>
        /// <param name="request"><see cref="UpdateStandardTermRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="UpdateStandardTermRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="UpdateStandardTermRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="UpdateStandardTermRequest">object</see> is invalid.</exception>
        private static void ValidateUpdateStandardTermRequest(UpdateStandardTermRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.BillingClassificationType == null)
                throw new ArgumentNullException("The BillingClassificationType value is required.  Please correct and try the request again.");
            else if (request.TermId == null && request.TermSourcedId == null)
                throw new ArgumentNullException("Either a TermId or TermSourcedId value is required.  Please correct and try the request again.");
            else if (request.Name == null)
                throw new ArgumentNullException("The Name value is required.  Please correct and try the request again.");
            else if (request.DropAddPeriodStartDate != DateTime.MinValue && request.CourseActualStartDate != DateTime.MinValue)
            {
                if (request.DropAddPeriodStartDate == request.CourseActualStartDate)
                    throw new ArgumentException("The DropAddPeriodStartDate value is set to the CourseActualStartDate.  This could cause downstream integration issues with the LearningStudio Enrollment API.  " +
                        "Best practice is to set the DropAddPeriodEndDate = CourseActualEndDate and set the DropAddPeriodStartDate = (CourseActualEndDate - 1 Day).  Please correct and try the request again.");
            }
            else if (request.TermId != null && request.TermSourcedId != null)
                throw new ArgumentException("The TermId and TermSourcedId values are mutually exclusive.  Only set one of the values for a given Term.  Please correct and try the request again.");
            else if (request.CourseActualEndDate != DateTime.MinValue && request.CourseActualStartDate != DateTime.MinValue)
            {
                if (request.CourseActualEndDate <= request.CourseActualStartDate)
                    throw new ArgumentOutOfRangeException("The CourseActualStartDate must be before the CourseActualEndDate.  Please correct and try the request again.");
            }
            else if (request.DropAddPeriodEndDate != DateTime.MinValue && request.DropAddPeriodStartDate != DateTime.MinValue)
            {
                if (request.DropAddPeriodEndDate <= request.DropAddPeriodStartDate)
                    throw new ArgumentOutOfRangeException("The DropAddPeriodStartDate must be before the DropAddPeriodEndDate.  Best practice is to set the DropAddPeriodEndDate = CourseActualEndDate and set the " +
                        "DropAddPeriodStartDate = (CourseActualEndDate - 1 Day).  Please correct and try the request again.");
            }
            else if (request.TermEndDate != DateTime.MinValue && request.TermStartDate != DateTime.MinValue)
            { 
                if (request.TermEndDate <= request.TermStartDate)
                    throw new ArgumentOutOfRangeException("The TermStartDate must be before the TermEndDate.  Please correct and try the request again.");
            }
            else if (request.RegistrationEndDate != DateTime.MinValue && request.RegistrationStartDate != DateTime.MinValue) 
            {
                if (request.RegistrationEndDate <= request.RegistrationStartDate)
                    throw new ArgumentOutOfRangeException("The RegistrationStartDate must be before the RegistrationEndDate.  Please correct and try the request again.");
            }
            else if (request.TermSourcedId != null)
            {
                if (!request.TermSourcedId.Contains(":"))
                    throw new ArgumentOutOfRangeException("The TermSourcedId should have a format of \"{Source}:{Id}\".  Note the colon delimiter that seperates the two concatenated values.  " +
                        "In addition, please use your ClientString as the {Source} portion of this concatenated value.  Please correct and try the request again.");
            }
        }

        #endregion
    }
}
