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
using Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request;
using Com.Pearson.Pdn.Learningstudio.SIS.Utility;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Courses
{
    /// <summary>
    /// CourseService Class
    /// </summary>
    public class CourseService
    {
        private API.EnterpriseCourseServiceClient courseAPI;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CourseService));
        private const string API_BINDING = "CustomBinding_EnterpriseCourseService";
        private const string CONTENT_COPY_OPTIONS = "All";
        private const string INTERNAL_IDENTIFIER = "ECLG:";

        #region Public Methods

        /// <summary>
        /// Constructors a new CourseService
        /// </summary>
        /// <param name="config"><s</param>
        public CourseService(APIConfig config)
        {
            // Initiallize the Course API and Set the Username Token Credentials
            this.courseAPI = new API.EnterpriseCourseServiceClient(API_BINDING);
            this.courseAPI.ClientCredentials.UserName.UserName = config.Username;
            this.courseAPI.ClientCredentials.UserName.Password = config.Password;
            
            // Intiallize log4net
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Generates a CopyCourseContent Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseContentRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response CopyCourseContent(CopyCourseContentRequest request)
        {
            API.ContentCopyRequestEx copyContent = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateCopyCourseContentRequest(request);

                // Intialize and Set the CopyCourseContentRequest
                copyContent = SetCopyCourseContentRequest(request);

                // Build the Response object from the SOAP response
                response = ReadCopyCourseContentResponse(copyContent);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from CopyCourseContent: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;
        }

        /// <summary>
        /// Generates a CopyCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response CopyCourseSection(CopyCourseSectionRequest request)
        {
            API.CourseSectionCopyRequestEx copyCourseSection = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateCopyCourseSectionRequest(request);

                // Intialize and Set the CopyCourseSectionRequest
                copyCourseSection = SetCopyCourseSectionRequest(request);

                // Build the Response object from the SOAP response
                response = ReadCopyCourseSectionResponse(copyCourseSection);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from GenerateCopyCourseSectionRequest: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;
        }

        /// <summary>
        /// Generates a CopyCourseSectionAndContent Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionAndContentRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response CopyCourseSectionAndContent(CopyCourseSectionAndContentRequest request)
        {
            API.CopyCourseRequestEx copyCourse = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateCopyCourseSectionAndContentRequest(request);

                // Intialize and Set the CopyCourseSectionAndContentRequest
                copyCourse = SetCopyCourseSectionAndContentRequest(request);

                // Build the Response Object from the SOAP Response
                response = ReadCopyCourseSectionAndContentResponse(copyCourse);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from CopyCourseSectionAndContent: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;            
        }

        /// <summary>
        /// Generates a CreateCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="CreateCourseSectionRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response CreateCourseSection(CreateCourseSectionRequest request)
        {
            API.CourseMessage createCourse = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateCreateCourseSectionRequest(request);
                
                // Intialize and Set the CreateCourseSectionRequest
                createCourse = SetCreateCourseSectionRequest(request);

                // Build the Response object from the SOAP response
                response = ReadCreateCourseSectionResponse(createCourse);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from CreateCourseSection: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;
        }

        /// <summary>
        /// Generates a RemoveCourseCallNumbers Course API Request
        /// </summary>
        /// <param name="request"><see cref="RevmoveCourseCallNumbersRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response RemoveCourseCallNumbers(RemoveCourseCallNumbersRequest request)
        {
            API.CallNumbersRemoveRequest removeCourseCallNumbers = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateRemoveCourseCallNumbersRequest(request);

                // Intialize and Set the RemoveCourseCallNumbersRequest
                removeCourseCallNumbers = SetRemoveCourseCallNumbersRequest(request);

                // Build the Response object from the SOAP response
                response = ReadRemoveCourseCallNumbersResponse(removeCourseCallNumbers);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from RemoveCourseCallNumbers: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;
        }

        /// <summary>
        /// Generates a UpdateCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="UpdateCourseSectionRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        public Response UpdateCourseSection(UpdateCourseSectionRequest request)
        {
            API.CourseSectionUpdateRequest updateCourseSection = null;
            Response response = null;

            try
            {
                // Validate the Request Object
                ValidateUpdateCourseSectionRequest(request);

                // Intialize and Set the CopyCourseSectionRequest
                updateCourseSection = SetUpdateCourseSectionRequest(request);

                // Build the Response object from the SOAP response
                response = ReadUpdateCourseSectionResponse(updateCourseSection);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception from UpdateCourseSection: ", ex);
                throw;
            }
            finally
            {
                if (this.courseAPI != null)
                    this.courseAPI.Close();
            }

            return response;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the XML payload for the CopyCourseContent Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseContentRequest">object</see></param>
        /// <returns><see cref="API.ContentCopyRequestEx"/>object</returns>
        private API.ContentCopyRequestEx SetCopyCourseContentRequest(CopyCourseContentRequest request)
        {
            // Initialize and Set the CopyCourseContentRequest
            API.ContentCopyRequestEx copyCourseContent = new API.ContentCopyRequestEx();
            copyCourseContent.ClientString = request.ClientString;
            copyCourseContent.CopyContentOptions = CONTENT_COPY_OPTIONS;
            copyCourseContent.DestinationCourseIdentifiers = new API.CourseIdentifier[1];
            copyCourseContent.DestinationCourseIdentifiers[0] = new API.CourseIdentifier();
            copyCourseContent.DestinationCourseIdentifiers[0].ID = request.DestinationCourseCallNumber;
            copyCourseContent.DestinationCourseIdentifiers[0].MappingType = API.MappedIDType.CallNumber;
            copyCourseContent.SourceClientSortString = request.SourceClientSortString;
            copyCourseContent.SourceCourseIdentifier = new API.CourseIdentifier();

            // Set the Source Coruse Identifier accordingly
            if (request.SourceCourseId != null)
            {
                copyCourseContent.SourceCourseIdentifier.ID = request.SourceCourseId;
                copyCourseContent.SourceCourseIdentifier.MappingType = API.MappedIDType.CourseID;
            }
            else
            {
                copyCourseContent.SourceCourseIdentifier.ID = request.SourceCourseCallNumber;
                copyCourseContent.SourceCourseIdentifier.MappingType = API.MappedIDType.CallNumber;
            }

            return copyCourseContent;
        }

        /// <summary>
        /// Creates the XML payload for the CopyCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionRequest">object</see></param>
        /// <returns><see cref="API.CourseSectionCopyRequestEx"/>object</returns>
        private API.CourseSectionCopyRequestEx SetCopyCourseSectionRequest(CopyCourseSectionRequest request)
        {
            // Initialize and Set the CopyCourseSectionRequest
            API.CourseSectionCopyRequestEx copyCourseSection = new API.CourseSectionCopyRequestEx();
            copyCourseSection.ClientString = request.ClientString;
            copyCourseSection.DestinationClientSortString = request.DestinationClientSortString;
            copyCourseSection.DestinationCourseIdentifiers = new API.CourseIdentifier[1];
            copyCourseSection.DestinationCourseIdentifiers[0] = new API.CourseIdentifier();

            // If more then 1 Call Number is used set them accordingly
            if (request.DestinationCourseCallNumbers.Length > 1)
            {
                // Initialize the CourseCallNumbers Object
                copyCourseSection.DestinationCourseIdentifiers[0].CourseCallNumbers = new API.CourseCallNumber[request.DestinationCourseCallNumbers.Length - 1];
                
                // Loop through the Call Numbers in the Request; the 1st is set in the DestinationCoruseIdentifier
                // the remainder, 2nd through n, are set in the CourseCallNumbers Object
                for (int i = 0; i < request.DestinationCourseCallNumbers.Length; i++)
                {
                    // Set the 1st Call Number accordingly, the rest are set in the CourseCallNumbers Object
                    if (i == 0)
                    {
                        copyCourseSection.DestinationCourseIdentifiers[0].ID = request.DestinationCourseCallNumbers[i];
                        copyCourseSection.DestinationCourseIdentifiers[0].MappingType = API.MappedIDType.CallNumber;
                    }
                    else
                    {
                        copyCourseSection.DestinationCourseIdentifiers[0].CourseCallNumbers[i - 1] = new API.CourseCallNumber();
                        copyCourseSection.DestinationCourseIdentifiers[0].CourseCallNumbers[i - 1].ClientCallNumber = request.DestinationCourseCallNumbers[i];
                    }
                }
            }
            else
            {                
                copyCourseSection.DestinationCourseIdentifiers[0].ID = request.DestinationCourseCallNumbers[0];
                copyCourseSection.DestinationCourseIdentifiers[0].MappingType = API.MappedIDType.CallNumber;
            }

            copyCourseSection.DestinationDisplayCourseCode = request.DestinationDisplayCourseCode;
            copyCourseSection.DestinationSectionDescription = request.DestinationSectionDescription;
            copyCourseSection.DestinationSectionNumber = request.DestinationSectionNumber;
            copyCourseSection.DestinationSectionTitle = request.DestinationSectionTitle;
            copyCourseSection.DestinationTermID = 0;
            copyCourseSection.DestinationTermIdentifier = new API.TermIdentifier();
            
            // Set the Destination Term Identifier accordingly
            if (request.DestinationTermId != null)
            {
                copyCourseSection.DestinationTermIdentifier.ID = INTERNAL_IDENTIFIER + request.DestinationTermId;
                copyCourseSection.DestinationTermIdentifier.MappingType = API.MappedTermIDType.TermID;
            }
            else
            {
                copyCourseSection.DestinationTermIdentifier.ID = request.DestinationTermSourcedId;
                copyCourseSection.DestinationTermIdentifier.MappingType = API.MappedTermIDType.SourcedID;
            }

            copyCourseSection.IsACrossList = false;
            copyCourseSection.SourceCourseIdentifier = new API.CourseIdentifier();

            // Set the Source Coruse Identifier accordingly
            if (request.SourceCourseId != null)
            {
                copyCourseSection.SourceCourseIdentifier.ID = request.SourceCourseId;
                copyCourseSection.SourceCourseIdentifier.MappingType = API.MappedIDType.CourseID;
            }
            else
            {
                copyCourseSection.SourceCourseIdentifier.ID = request.SourceCourseCallNumber;
                copyCourseSection.SourceCourseIdentifier.MappingType = API.MappedIDType.CallNumber;
            }

            return copyCourseSection;
        }

        /// <summary>
        /// Creates the XML payload for the CopyCourseSectionAndContent Course API Request
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionAndContentRequest">object</see></param>
        /// <returns><see cref="API.CopyCourseRequestEx"/>object</returns>
        private API.CopyCourseRequestEx SetCopyCourseSectionAndContentRequest(CopyCourseSectionAndContentRequest request)
        {
            API.CopyCourseRequestEx copyCourse = new API.CopyCourseRequestEx();
            copyCourse.ClientString = request.ClientString;
            copyCourse.CopyContentOptions = CONTENT_COPY_OPTIONS;
            copyCourse.DestinationClientSortString = request.DestinationClientSortString;
            copyCourse.DestinationCourseIdentifiers = new API.CourseIdentifier[1];
            copyCourse.DestinationCourseIdentifiers[0] = new API.CourseIdentifier();

            // If more then 1 Call Number is used set them accordingly
            if (request.DestinationCourseCallNumbers.Length > 1)
            {
                // Initialize the CourseCallNumbers Object
                copyCourse.DestinationCourseIdentifiers[0].CourseCallNumbers = new API.CourseCallNumber[request.DestinationCourseCallNumbers.Length - 1];

                // Loop through the Call Numbers in the Request; the 1st is set in the DestinationCoruseIdentifier
                // the remainder, 2nd through n, are set in the CourseCallNumbers Object
                for (int i = 0; i < request.DestinationCourseCallNumbers.Length; i++)
                {
                    // Set the 1st Call Number accordingly, the rest are set in the CourseCallNumbers Object
                    if (i == 0)
                    {
                        copyCourse.DestinationCourseIdentifiers[0].ID = request.DestinationCourseCallNumbers[i];
                        copyCourse.DestinationCourseIdentifiers[0].MappingType = API.MappedIDType.CallNumber;
                    }
                    else
                    {
                        copyCourse.DestinationCourseIdentifiers[0].CourseCallNumbers[i - 1] = new API.CourseCallNumber();
                        copyCourse.DestinationCourseIdentifiers[0].CourseCallNumbers[i - 1].ClientCallNumber = request.DestinationCourseCallNumbers[i];
                    }
                }
            }
            else
            {
                copyCourse.DestinationCourseIdentifiers[0].ID = request.DestinationCourseCallNumbers[0];
                copyCourse.DestinationCourseIdentifiers[0].MappingType = API.MappedIDType.CallNumber;
            }

            copyCourse.DestinationDisplayCourseCode = request.DestinationDisplayCourseCode;
            copyCourse.DestinationSectionDescription = request.DestinationSectionDescription;
            copyCourse.DestinationSectionNumber = request.DestinationSectionNumber;
            copyCourse.DestinationSectionTitle = request.DestinationSectionTitle;
            copyCourse.DestinationTermID = 0;
            copyCourse.DestinationTermIdentifier = new API.TermIdentifier();

            // Set the Destination Term Identifier accordingly
            if (request.DestinationTermId != null)
            {
                copyCourse.DestinationTermIdentifier.ID = INTERNAL_IDENTIFIER + request.DestinationTermId;
                copyCourse.DestinationTermIdentifier.MappingType = API.MappedTermIDType.TermID;
            }
            else
            {
                copyCourse.DestinationTermIdentifier.ID = request.DestinationTermSourcedId;
                copyCourse.DestinationTermIdentifier.MappingType = API.MappedTermIDType.SourcedID;
            }

            copyCourse.SourceClientSortString = request.SourceClientSortString;
            copyCourse.SourceCourseIdentifier = new API.CourseIdentifier();

            // Set the Source Coruse Identifier accordingly
            if (request.SourceCourseId != null)
            {
                copyCourse.SourceCourseIdentifier.ID = request.SourceCourseId;
                copyCourse.SourceCourseIdentifier.MappingType = API.MappedIDType.CourseID;
            }
            else
            {
                copyCourse.SourceCourseIdentifier.ID = request.SourceCourseCallNumber;
                copyCourse.SourceCourseIdentifier.MappingType = API.MappedIDType.CallNumber;
            }

            return copyCourse;
        }

        /// <summary>
        /// Creates the XML payload for the CreateCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="CreateCourseSectionRequest">object</see></param>
        /// <returns><see cref="API.CourseMessage"/>object</returns>
        private API.CourseMessage SetCreateCourseSectionRequest(CreateCourseSectionRequest request)
        {
            // Initialize and Set the CopyCourseSectionRequest
            API.CourseMessage createCourse = new API.CourseMessage();
            createCourse.BillingClassification = request.BillingClassification;
            createCourse.ClientString = request.ClientString;
            createCourse.CourseVersion = API.CourseType.DotNext;
            createCourse.DestinationCourseIdentifier = new API.CourseIdentifier();
            createCourse.DestinationCourseIdentifier.ID = request.DestinationCourseCallNumber;
            createCourse.DestinationCourseIdentifier.MappingType = API.MappedIDType.CallNumber;
            createCourse.DestinationTermIdentifier = new API.TermIdentifier();

            // Set the Destination Term Identifier accordingly
            if (request.DestinationTermId != null)
            {
                createCourse.DestinationTermIdentifier.ID = INTERNAL_IDENTIFIER + request.DestinationTermId;
                createCourse.DestinationTermIdentifier.MappingType = API.MappedTermIDType.TermID;
            }
            else
            {
                createCourse.DestinationTermIdentifier.ID = request.DestinationTermSourcedId;
                createCourse.DestinationTermIdentifier.MappingType = API.MappedTermIDType.SourcedID;
            }

            createCourse.DisplayCourseCode = request.DisplayCourseCode;
            createCourse.IsEnrollable = true;
            createCourse.PrimaryClientSortString = request.PrimaryClientSortString;
            createCourse.SectionDescription = request.SectionDescription;
            createCourse.SectionNumber = request.SectionNumber;
            createCourse.SectionTitle = request.SectionTitle;

            return createCourse;
        }

        /// <summary>
        /// Creates the XML payload for the RemoveCourseCallNumbers Course API Request
        /// </summary>
        /// <param name="request"><see cref="RemoveCoruseCallNumbersRequest">object</see></param>
        /// <returns><see cref="API.CallNumbersRemoveRequest"/>object</returns>
        private API.CallNumbersRemoveRequest SetRemoveCourseCallNumbersRequest(RemoveCourseCallNumbersRequest request)
        {
            // Initialize and Set the RemoveCourseCallNumbersRequest
            API.CallNumbersRemoveRequest removeCourseCallNumbers = new API.CallNumbersRemoveRequest();
            removeCourseCallNumbers.ClientString = request.ClientString;
            removeCourseCallNumbers.DestinationCourseIdentifier = new API.CourseIdentifier();

            // If removing more then 1 CallNumber set CourseCallNumbers object accordingly
            if (request.RemoveCourseCallNumbers.Length > 1)
            {
                // Initialize the CourseCallNumbers Object
                removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers = new API.CourseCallNumber[request.RemoveCourseCallNumbers.Length];

                // Loop through the Call Numbers in the Request
                for (int i = 0; i < request.RemoveCourseCallNumbers.Length; i++)
                {
                    removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers[i] = new API.CourseCallNumber();
                    removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers[i].ClientCallNumber = request.RemoveCourseCallNumbers[i];
                }
            }
            else
            {
                // Only 1 CallNumber to remove, set accordingly
                removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers = new API.CourseCallNumber[1];
                removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers[0] = new API.CourseCallNumber();
                removeCourseCallNumbers.DestinationCourseIdentifier.CourseCallNumbers[0].ClientCallNumber = request.RemoveCourseCallNumbers[0];
            }

            // Set the DestinationIdentifier accordingly
            if (request.DestinationCourseId != null)
            {           
                removeCourseCallNumbers.DestinationCourseIdentifier.ID = request.DestinationCourseId;
                removeCourseCallNumbers.DestinationCourseIdentifier.MappingType = API.MappedIDType.CourseID;
            }
            else
            {
                removeCourseCallNumbers.DestinationCourseIdentifier.ID = request.DestinationCourseCallNumber;
                removeCourseCallNumbers.DestinationCourseIdentifier.MappingType = API.MappedIDType.CallNumber;
            }

            return removeCourseCallNumbers;
        }

        /// <summary>
        /// Creates the XML payload for the UpdateCourseSection Course API Request
        /// </summary>
        /// <param name="request"><see cref="UpdateCourseSectionRequest">object</see></param>
        /// <returns><see cref="API.CourseSectionUpdateRequest"/>object</returns>
        private API.CourseSectionUpdateRequest SetUpdateCourseSectionRequest(UpdateCourseSectionRequest request)
        {
            // Initialize and Set the UpdateCourseSectionRequest
            API.CourseSectionUpdateRequest updateCourseSection = new API.CourseSectionUpdateRequest();
            updateCourseSection.ClientString = request.ClientString;
            updateCourseSection.DestinationCourseIdentifier = new API.CourseIdentifier();

            // If Adding CallNumbers set CourseCallNumbers object accordingly
            if (request.AddCourseCallNumbers != null)
            {
                // Initialize the CourseCallNumbers Object
                updateCourseSection.DestinationCourseIdentifier.CourseCallNumbers = new API.CourseCallNumber[request.AddCourseCallNumbers.Length];

                // Loop through the Call Numbers in the Request
                for (int i = 0; i < request.AddCourseCallNumbers.Length; i++)
                {
                    updateCourseSection.DestinationCourseIdentifier.CourseCallNumbers[i] = new API.CourseCallNumber();
                    updateCourseSection.DestinationCourseIdentifier.CourseCallNumbers[i].ClientCallNumber = request.AddCourseCallNumbers[i];
                }
            }

            // Set the DestinationCourseCallNumber
            updateCourseSection.DestinationCourseIdentifier.ID = request.DestinationCourseCallNumber;
            updateCourseSection.DestinationCourseIdentifier.MappingType = API.MappedIDType.CallNumber;

            updateCourseSection.DestinationDisplayCourseCode = request.DestinationDisplayCourseCode;
            updateCourseSection.DestinationSectionDescription = request.DestinationSectionDescription;
            updateCourseSection.DestinationSectionNumber = request.DestinationSectionNumber;
            updateCourseSection.DestinationSectionTitle = request.DestinationSectionTitle;
            updateCourseSection.PrimaryClientSortString = request.PrimaryClientSortString;

            return updateCourseSection;
        }

        /// <summary>
        /// Sends the CopyCourseContent request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.ContentCopyRequestEx">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadCopyCourseContentResponse(API.ContentCopyRequestEx request)
        {
            Response response = new Response();
            API.ContentCopyStatus contentCopyStatus = new API.ContentCopyStatus();

            try
            {
                contentCopyStatus = this.courseAPI.CopyCourseContent(request);

                XElement xe = XMLHelper.ParseXML<API.ContentCopyStatus>(contentCopyStatus);

                response.Content = xe.ToString();
                response.ContentType = "text/xml";
                response.StatusCode = contentCopyStatus.Status;

                // Handle the Response Status accordingly
                if (contentCopyStatus.Status == "Ok" && contentCopyStatus.JobStatusID != "0")
                    response.StatusMessage = String.Format("CopyCourseContentRequest succesfully submitted for processing!  Copy Job ID: {0}.  For additional processing information please use the Admin Pages and refer to the Copy Job ID included in this response.", contentCopyStatus.JobStatusID);
                else if (contentCopyStatus.Status == "Ok" && contentCopyStatus.JobStatusID == "0")
                    response.StatusMessage = String.Format("CopyCourseContentRequest was not submitted for processing.  Please confirm the DestinationCourseCallNumber is correct and that this Course dose not already contain Course Content.  DestinationCourseCallNumber: {0}", request.DestinationCourseIdentifiers[0].ID);
                else
                    response.StatusMessage = contentCopyStatus.Status;
            }
            catch (FaultException ex)
            {
                // Serialize the Fault Details
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
        /// Sends the CopyCourseSection request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.CourseSectionCopyRequestEx">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadCopyCourseSectionResponse(API.CourseSectionCopyRequestEx request)
        {
            Response response = new Response();
            API.ContentCopyStatus contentCopyStatus = new API.ContentCopyStatus();

            try
            {
                contentCopyStatus = this.courseAPI.CopyCourseSection(request);

                XElement xe = XMLHelper.ParseXML<API.ContentCopyStatus>(contentCopyStatus);

                response.Content = xe.ToString();
                response.ContentType = "text/xml";
                response.StatusCode = contentCopyStatus.Status;

                // Handle the Response Status accordingly
                if (contentCopyStatus.Status == "Ok")
                    response.StatusMessage = "Course Copy Sucessful!";
                else if (contentCopyStatus.ID.MappingType == API.MappedIDType.CourseID)
                    response.StatusMessage = String.Format("Course Created, CourseId: {0}.  However, the CallNumbers could not be added to the Course since they are already in use.", contentCopyStatus.ID.ID);
                else
                    response.StatusMessage = contentCopyStatus.Status;
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
        /// Sends the CopyCourseSectionAndContent request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.CopyCourseRequestEx">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadCopyCourseSectionAndContentResponse(API.CopyCourseRequestEx request)
        {
            Response response = new Response();
            API.ContentCopyStatus contentCopyStatus = new API.ContentCopyStatus();

            try
            {
                contentCopyStatus = this.courseAPI.CopyCourseSectionAndContent(request);

                XElement xe = XMLHelper.ParseXML<API.ContentCopyStatus>(contentCopyStatus);

                response.Content = xe.ToString();
                response.ContentType = "text/xml";
                response.StatusCode = contentCopyStatus.Status;

                // Handle the Response Status accordingly
                if (contentCopyStatus.Status == "Ok" && contentCopyStatus.JobStatusID != "0")
                    response.StatusMessage = String.Format("CopyCourseSectionAndContentRequest succesfully submitted for processing!  Copy Job ID: {0}.  For additional processing information please use the Admin Pages and refer to the Copy Job ID included in this response.", contentCopyStatus.JobStatusID);
                else if (contentCopyStatus.Status == "Ok" && contentCopyStatus.JobStatusID == "0")
                    response.StatusMessage = String.Format("CopyCourseSectionAndContentRequest was not submitted for processing.  Please confirm the DestinationCourseCallNumber is correct and that this Course dose not already contain Course Content.  DestinationCourseCallNumber: {0}", request.DestinationCourseIdentifiers[0].ID);
                else
                    response.StatusMessage = contentCopyStatus.Status;
            }
            catch (FaultException ex)
            {
                // Serialize the Fault Details
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
        /// Sends the CreateCourseSection request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.CourseMessage">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadCreateCourseSectionResponse(API.CourseMessage request)
        {
            Response response = new Response();
            API.CourseKeysMessage createCourseStatus = new API.CourseKeysMessage();

            try
            {
                createCourseStatus = this.courseAPI.CreateCourseSection(request);

                XElement xe = XMLHelper.ParseXML<API.CourseKeysMessage>(createCourseStatus);

                response.Content = xe.ToString();
                response.ContentType = "text/xml";

                // Handle the Response Status accordingly
                if (createCourseStatus.SectionKey > 0)
                {
                    response.StatusCode = "Ok";
                    response.StatusMessage = String.Format("Course Creation Successful!  CourseId: {0} ", createCourseStatus.SectionKey);
                }
            }
            catch (FaultException ex)
            {
                // Serialize the Fault Details
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
        /// Sends the RemoveCourseCallNumbers request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.CallNumbersRemoveRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadRemoveCourseCallNumbersResponse(API.CallNumbersRemoveRequest request)
        {
            Response response = new Response();
            long courseId = 0;

            try
            {
                courseId = this.courseAPI.RemoveCourseCallNumbers(request);
                response.ContentType = "text/plain";

                // Handle the Response accordingly
                if (courseId != 0)
                {
                    response.Content = String.Format("Course CallNumber(s) Successfully Removed!  CourseId: {0} ", courseId);
                    response.StatusCode = "Ok";
                    response.StatusMessage = response.Content;
                }
                else
                {
                    response.Content = "RemoveCourseCallNumbersRequest Failed.";
                    response.StatusCode = "Failure";
                    response.StatusMessage = response.Content;
                }
            }
            catch (FaultException ex)
            {
                // Serialize the Fault Details
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
        /// Sends the UpdateCourseSection request to the Course API
        /// </summary>
        /// <param name="request"><see cref="API.CourseSectionUpdateRequest">object</see></param>
        /// <returns><see cref="Response"/>object</returns>
        private Response ReadUpdateCourseSectionResponse(API.CourseSectionUpdateRequest request)
        {
            Response response = new Response();
            API.ContentCopyStatus contentCopyStatus = new API.ContentCopyStatus();

            try
            {
                contentCopyStatus = this.courseAPI.UpdateCourseSection(request);

                XElement xe = XMLHelper.ParseXML<API.ContentCopyStatus>(contentCopyStatus);

                response.Content = xe.ToString();
                response.ContentType = "text/xml";

                // Handle the Response Status accordingly
                if (contentCopyStatus.Status == null)
                {
                    response.StatusCode = "Ok";
                    response.StatusMessage = String.Format("UpdateCourseSectionRequest was successful! CallNumber: {0}", contentCopyStatus.ID.ID);
                }
                else
                {
                    response.StatusCode = "Failure";
                    response.StatusMessage = contentCopyStatus.Status;
                }
            }
            catch (FaultException ex)
            {
                // Serialize the Fault Details
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
        /// Performs validation and business logic checks on the CopyCourseContentRequest values
        /// </summary>
        /// <param name="request"><see cref="CopyCourseContentRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="CopyCourseContentRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="CopyCourseContentRequest">object</see></exception>
        private static void ValidateCopyCourseContentRequest(CopyCourseContentRequest request)
        {
            // Perform a Parameter Validation and Business Logice Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.DestinationCourseCallNumber == null)
                throw new ArgumentNullException("The DestinationCourseCallNumber value is required.  Please correct and try the request again.");
            else if (request.SourceClientSortString == null)
                throw new ArgumentNullException("The SourceClientSortString value is required.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber == null && request.SourceCourseId == null)
                throw new ArgumentNullException("Either a SourceCourseCallNumber or SourceCourseId value is required.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber != null && request.SourceCourseId != null)
                throw new ArgumentException("The SourceCourseCallNumber and SourceCourseId values are mutually exclusive.  Only set one of the values for a given Source Coruse.  Please correct and try the request again.");
        }

        /// <summary>
        /// Performs validation and business logic checks on the CopyCourseSectionRequest values
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="CopyCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="CopyCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="CopyCourseSectionRequest">object</see> is invalid.</exception>
        private static void ValidateCopyCourseSectionRequest(CopyCourseSectionRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.DestinationClientSortString == null)
                throw new ArgumentNullException("The DestinationClientSortString value is required.  Please correct and try the request again.");
            else if (request.DestinationCourseCallNumbers == null)
                throw new ArgumentNullException("The DestinationCourseCallNumbers value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId == null && request.DestinationTermSourcedId == null)
                throw new ArgumentNullException("Either a DestinationTermId or DestinationTermSourcedId value is required.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber == null && request.SourceCourseId == null)
                throw new ArgumentNullException("Either a SourceCourseCallNumber or SourceCourseId value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId != null && request.DestinationTermSourcedId != null)
                throw new ArgumentException("The DestinationTermId and DestinationTermSourcedId values are mutually exclusive.  Only set one of the values for a given Destination Term.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber != null && request.SourceCourseId != null)
                throw new ArgumentException("The SourceCourseCallNumber and SourceCourseId values are mutually exclusive.  Only set one of the values for a given Source Coruse.  Please correct and try the request again.");
            else if (request.DestinationSectionNumber > 255)
                throw new ArgumentOutOfRangeException("The DestinationSectionNumber has a Maximum allowed Value of 255.  Please correct and try the request again.");
            else if (request.DestinationTermSourcedId != null)
                if (!request.DestinationTermSourcedId.Contains(":"))
                    throw new ArgumentOutOfRangeException("The DestinationTermSourcedId should have a format of \"{Source}:{Id}\".  Note the colon delimiter that seperates the two concatenated values.  " +
                        "In addition, please use your ClientString as the {Source} portion of this concatenated value.  Please correct and try the request again.");                
        }

        /// <summary>
        /// Performs validation and business logic checks on the CopyCourseSectionAndContentRequest values
        /// </summary>
        /// <param name="request"><see cref="CopyCourseSectionAndContentRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="CopyCourseSectionAndContentRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="CopyCourseSectionAndContentRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="CopyCourseSectionAndContentRequest">object</see> is invalid.</exception>
        private static void ValidateCopyCourseSectionAndContentRequest(CopyCourseSectionAndContentRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.DestinationClientSortString == null)
                throw new ArgumentNullException("The DestinationClientSortString value is required.  Please correct and try the request again.");
            else if (request.DestinationCourseCallNumbers == null)
                throw new ArgumentNullException("The DestinationCourseCallNumbers value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId == null && request.DestinationTermSourcedId == null)
                throw new ArgumentNullException("Either a DestinationTermId or DestinationTermSourcedId value is required.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber == null && request.SourceCourseId == null)
                throw new ArgumentNullException("Either a SourceCourseCallNumber or SourceCourseId value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId != null && request.DestinationTermSourcedId != null)
                throw new ArgumentException("The DestinationTermId and DestinationTermSourcedId values are mutually exclusive.  Only set one of the values for a given Destination Term.  Please correct and try the request again.");
            else if (request.SourceClientSortString == null)
                throw new ArgumentNullException("The SourceClientSortString value is required.  Please correct and try the request again.");
            else if (request.SourceCourseCallNumber != null && request.SourceCourseId != null)
                throw new ArgumentException("The SourceCourseCallNumber and SourceCourseId values are mutually exclusive.  Only set one of the values for a given Source Coruse.  Please correct and try the request again.");
            else if (request.DestinationSectionNumber > 255)
                throw new ArgumentOutOfRangeException("The DestinationSectionNumber has a Maximum allowed Value of 255.  Please correct and try the request again.");
            else if (request.DestinationTermSourcedId != null)
                if (!request.DestinationTermSourcedId.Contains(":"))
                    throw new ArgumentOutOfRangeException("The DestinationTermSourcedId should have a format of \"{Source}:{Id}\".  Note the colon delimiter that seperates the two concatenated values.  " +
                        "In addition, please use your ClientString as the {Source} portion of this concatenated value.  Please correct and try the request again.");
        }

        /// <summary>
        /// Performs validation and business logic checks on the CopyCourseSectionAndContentRequest values
        /// </summary>
        /// <param name="request"><see cref="CreateCourseSectionRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="CreateCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="CreateCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="CreateCourseSectionRequest">object</see> is invalid.</exception>
        private static void ValidateCreateCourseSectionRequest(CreateCourseSectionRequest request)
        {
            // Perform a Parameter Validation and Business Logic Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.PrimaryClientSortString == null)
                throw new ArgumentNullException("The PrimaryClientSortString value is required.  Please correct and try the request again.");
            else if (request.DestinationCourseCallNumber == null)
                throw new ArgumentNullException("The DestinationCourseCallNumber value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId == null && request.DestinationTermSourcedId == null)
                throw new ArgumentNullException("Either a DestinationTermId or DestinationTermSourcedId value is required.  Please correct and try the request again.");
            else if (request.DisplayCourseCode == null)
                throw new ArgumentNullException("The DisplayCourseCode value is required.  Please correct and try the request again.");
            else if (request.SectionTitle == null)
                throw new ArgumentNullException("The SectionTitle value is required.  Please correct and try the request again.");
            else if (request.DestinationTermId != null && request.DestinationTermSourcedId != null)
                throw new ArgumentException("The DestinationTermId and DestinationTermSourcedId values are mutually exclusive.  Only set one of the values for a given Destination Term.  Please correct and try the request again.");
            else if (request.SectionNumber > 255)
                throw new ArgumentOutOfRangeException("The SectionNumber has a Maximum allowed Value of 255.  Please correct and try the request again.");
            else if (request.DestinationTermSourcedId != null)
                if (!request.DestinationTermSourcedId.Contains(":"))
                    throw new ArgumentOutOfRangeException("The DestinationTermSourcedId should have a format of \"{Source}:{Id}\".  Note the colon delimiter that seperates the two concatenated values.  " +
                        "In addition, please use your ClientString as the {Source} portion of this concatenated value.  Please correct and try the request again.");
        }

        /// <summary>
        /// Performs validation and business logic checks on the RemoveCourseCallNumbersRequest values
        /// </summary>
        /// <param name="request"><see cref="RemoveCourseCallNumbersRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="RemoveCourseCallNumbersRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="RemoveCourseCallNumbersRequest">object</see></exception>
        private static void ValidateRemoveCourseCallNumbersRequest(RemoveCourseCallNumbersRequest request)
        {
            // Perform a Parameter Validation and Business Logice Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.DestinationCourseCallNumber == null && request.DestinationCourseId == null)
                throw new ArgumentNullException("Either a DestinationCourseCallNumber or DestinationCourseId value is required.  Please correct and try the request again.");
            else if (request.RemoveCourseCallNumbers == null)
                throw new ArgumentNullException("The RemoveCourseCallNumbers value is required.  Please correct and try the request again.");
            else if (request.DestinationCourseCallNumber != null && request.DestinationCourseId != null)
                throw new ArgumentException("The DestinationCourseCallNumber and DestinationCourseId values are mutually exclusive.  Only set one of the values for a given Destination Course.  Please correct and try the request again.");
        }

        /// <summary>
        /// Performs validation and business logic checks on the UpdateCourseSectionRequest values
        /// </summary>
        /// <param name="request"><see cref="UpdateCourseSectionRequest">object</see></param>
        /// <exception cref="ArgumentNullException">Thrown when a required value is not set in the <see cref="UpdateCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentException">Thrown when there is a conflict between the values in the <see cref="UpdateCourseSectionRequest">object</see></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value in the <see cref="UpdateCourseSectionRequest">object</see> is invalid.</exception>
        private static void ValidateUpdateCourseSectionRequest(UpdateCourseSectionRequest request)
        {
            // Perform a Parameter Validation and Business Logice Check on the Request
            if (request.ClientString == null)
                throw new ArgumentNullException("The ClientString value is required.  Please correct and try the reqeust again.");
            else if (request.PrimaryClientSortString == null)
                throw new ArgumentNullException("The PrimaryClientSortString value is required.  Please correct and try the request again.");
            else if (request.DestinationCourseCallNumber == null)
                throw new ArgumentNullException("The DestinationCourseCallNumber value is required.  Please correct and try the request again.");
            else if (request.DestinationSectionNumber > 255)
                throw new ArgumentOutOfRangeException("The DestinationSectionNumber has a Maximum allowed Value of 255.  Please correct and try the request again.");
        }

        #endregion 
    }
}
