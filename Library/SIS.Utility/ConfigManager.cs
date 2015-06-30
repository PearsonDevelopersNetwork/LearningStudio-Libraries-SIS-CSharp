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


namespace Com.Pearson.Pdn.Learningstudio.SIS.Utility
{
    /// <summary>
    /// This Class maps the various LearningStudio SIS API properties to the 
    /// appSettings values in a given Project's config file.
    /// </summary>
    public class ConfigManager
    {
        // UserService Values
        private const string CONST_SOURCE = "Source";
        private const string CONST_ID = "Id";
        private const string CONST_LOGIN_ID = "LoginId";
        private const string CONST_PASSWORD = "Password";
        private const string CONST_FIRST_NAME = "FirstName";
        private const string CONST_MIDDLE_NAME = "MiddleName";
        private const string CONST_LAST_NAME = "LastName";
        private const string CONST_GENDER = "Gender";
        private const string CONST_DOB = "DOB";
        private const string CONST_DISABILITY = "Disability";
        private const string CONST_EMAIL = "Email";
        private const string CONST_PHONE_NUMBER = "PhoneNumber";
        private const string CONST_ADDRESS_1 = "Address1";
        private const string CONST_ADDRESS_2 = "Address2";
        private const string CONST_CITY = "City";
        private const string CONST_STATE = "State";
        private const string CONST_ZIP_CODE = "ZipCode";
        private const string CONST_COUNTRY = "Country";
        private const string CONST_EXTENDED_USER_PROPERTIES = "ExtendedUserProperties";
        private const string CONST_CALL_NUMBER = "CallNumber";
        private const string CONST_NODE_STRING = "NodeString";
        private const string CONST_ROLE_ID = "RoleId";

        // Course Service Values
        private const string CONST_DESTINATION_CLIENT_SORT_STRING = "DestinationClientSortString";
        private const string CONST_PRIMARY_CLIENT_SORT_STRING = "PrimaryClientSortString";
        private const string CONST_DESTINATION_COURSE_CALL_NUMBER = "DestinationCourseCallNumber";
        private const string CONST_DESTINATION_COURSE_CALL_NUMBERS = "DestinationCourseCallNumbers";
        private const string CONST_ADD_COURSE_CALL_NUMBERS = "AddCourseCallNumbers";
        private const string CONST_REMOVE_COURSE_CALL_NUMBERS = "RemoveCourseCallNumbers";
        private const string CONST_DESTINATION_COURSE_ID = "DestinationCourseId";
        private const string CONST_DESTINATION_DISPLAY_COURSE_CODE = "DestinationDisplayCourseCode";
        private const string CONST_DISPLAY_COURSE_CODE = "DisplayCourseCode";
        private const string CONST_DESTINATION_SECTION_NUMBER = "DestinationSectionNumber";
        private const string CONST_SECTION_NUMBER = "SectionNumber";
        private const string CONST_DESTINATION_SECTION_TITLE = "DestinationSectionTitle";
        private const string CONST_SECTION_TITLE = "SectionTitle";
        private const string CONST_DESTINATION_SECTION_DESCRIPTION = "DestinationSectionDescription";
        private const string CONST_SECTION_DESCRIPTION = "SectionDescription";
        private const string CONST_DESTINATION_TERM_ID = "DestinationTermId";
        private const string CONST_DESTINATION_TERM_SOURCED_ID = "DestinationTermSourcedId";
        private const string CONST_SOURCE_CLIENT_SORT_STRING = "SourceClientSortString";
        private const string CONST_SOURCE_COURSE_CALL_NUMBER = "SourceCourseCallNumber";
        private const string CONST_SOURCE_COURSE_ID = "SourceCourseId";

        // Term Service Values
        private const string CONST_ASSOCIATED_EP_ORGANIZATION = "AssociatedEPOrganization";
        private const string CONST_COURSE_ACTUAL_START_DATE = "CourseActualStartDate";
        private const string CONST_COURSE_ACTUAL_END_DATE = "CourseActualEndDate";
        private const string CONST_DROP_ADD_PERIOD_START_DATE = "DropAddPeriodStartDate";
        private const string CONST_DROP_ADD_PERIOD_END_DATE = "DropAddPeriodEndDate";
        private const string CONST_TERM_ID = "TermId";
        private const string CONST_TERM_SOURCED_ID = "TermSourcedId";
        private const string CONST_NAME = "Name";
        private const string CONST_DESCRIPTION = "Description";
        private const string CONST_REGISTRATION_START_DATE = "RegistrationStartDate";
        private const string CONST_REGISTRATION_END_DATE = "RegistrationEndDate";
        private const string CONST_TERM_START_DATE = "TermStartDate";
        private const string CONST_TERM_END_DATE = "TermEndDate";
        private const string CONST_WITHDRAW_PERIOD_ENDS_ON = "WithdrawPeriodEndsOn";

        // Course & Term Service Shared Values
        private const string CONST_CLIENT_STRING = "ClientString";

        // Shared Values Across All Services
        private const string CONST_API_USERNAME = "APIUsername";
        private const string CONST_API_PASSWORD = "APIPassword";

        /// <summary>
        /// Gets the Source property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Source
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SOURCE);
            }
        }

        /// <summary>
        /// Gets the Id property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Id
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ID);
            }
        }

        /// <summary>
        /// Gets the LoginId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string LoginId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_LOGIN_ID);
            }
        }

        /// <summary>
        /// Gets the Password property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Password
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_PASSWORD);
            }
        }

        /// <summary>
        /// Gets the FirstName property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string FirstName
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_FIRST_NAME);
            }
        }

        /// <summary>
        /// Gets the MiddleName property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string MiddleName
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_MIDDLE_NAME);
            }
        }

        /// <summary>
        /// Gets the LastName property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string LastName
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_LAST_NAME);
            }
        }

        /// <summary>
        /// Gets the Gender property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Gender
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_GENDER);
            }
        }

        /// <summary>
        /// Gets the DOB property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string DOB
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DOB);
            }
        }

        /// <summary>
        /// Gets the Disability property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Disability
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DISABILITY);
            }
        }

        /// <summary>
        /// Gets the Email property from appSettins; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Email
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_EMAIL);
            }
        }

        /// <summary>
        /// Gets the PhoneNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string PhoneNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_PHONE_NUMBER);
            }
        }

        /// <summary>
        /// Gets the Address1 property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Address1
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ADDRESS_1);
            }
        }

        /// <summary>
        /// Gets the Address2 property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Address2
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ADDRESS_2);
            }
        }

        /// <summary>
        /// Gets the City property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string City
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_CITY);
            }
        }

        /// <summary>
        /// Gets the State property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string State
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_STATE);
            }
        }

        /// <summary>
        /// Gets the ZipCode property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string ZipCode
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ZIP_CODE);
            }
        }

        /// <summary>
        /// Gets the Country property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string Country
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_COUNTRY);
            }
        }

        /// <summary>
        /// Gets the ExtendedUserProperties property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string ExtendedUserProperties
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_EXTENDED_USER_PROPERTIES);
            }
        }

        /// <summary>
        /// Gets the CallNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string CallNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_CALL_NUMBER);
            }
        }

        /// <summary>
        /// Gets the NodeString property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string NodeString
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_NODE_STRING);
            }
        }

        /// <summary>
        /// Gets the RoleId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
        /// </summary>
        public static string RoleId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ROLE_ID);
            }
        }        

        /// <summary>
        /// Gets the DestinationClientSortString property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationClientSortString
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_CLIENT_SORT_STRING);
            }
        }

        /// <summary>
        /// Gets the PrimaryClientSortString property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string PrimaryClientSortString
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_CLIENT_SORT_STRING);
            }
        }

        /// <summary>
        /// Gets the DestinationCourseCallNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationCourseCallNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_COURSE_CALL_NUMBER);
            }
        }

        /// <summary>
        /// Gets the DestinationCourseCallNumbers property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationCourseCallNumbers
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_COURSE_CALL_NUMBERS);
            }
        }

        /// <summary>
        /// Gets the AddCourseCallNumbers property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string AddCourseCallNumbers
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ADD_COURSE_CALL_NUMBERS);
            }
        }

        /// <summary>
        /// Gets the RemoveCourseCallNumbers property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string RemoveCourseCallNumbers
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_REMOVE_COURSE_CALL_NUMBERS);
            }
        }

        /// <summary>
        /// Gets the DestinationCourseId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationCourseId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_COURSE_ID);
            }
        }

        /// <summary>
        /// Gets the DestinationDisplayCourseCode property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationDisplayCourseCode
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_DISPLAY_COURSE_CODE);
            }
        }

        /// <summary>
        /// Gets the DisplayCourseCode property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DisplayCourseCode
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DISPLAY_COURSE_CODE);
            }
        }

        /// <summary>
        /// Gets the DestinationSectionNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationSectionNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_SECTION_NUMBER);
            }
        }

        /// <summary>
        /// Gets the SectionNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SectionNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SECTION_NUMBER);
            }
        }

        /// <summary>
        /// Gets the DestinationSectionTitle property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationSectionTitle
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_SECTION_TITLE);
            }
        }

        /// <summary>
        /// Gets the SectionTitle property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SectionTitle
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SECTION_TITLE);
            }
        }

        /// <summary>
        /// Gets the DestinationSectionDescription property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationSectionDescription
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_SECTION_DESCRIPTION);
            }
        }

        /// <summary>
        /// Gets the SectionDescription property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SectionDescription
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SECTION_DESCRIPTION);
            }
        }

        /// <summary>
        /// Gets the DestinationTermId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationTermId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_TERM_ID);
            }
        }

        /// <summary>
        /// Gets the DestinationTermSourcedId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string DestinationTermSourcedId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESTINATION_TERM_SOURCED_ID);
            }
        }

        /// <summary>
        /// Gets the SourceClilentSortString property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SourceClientSortString
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SOURCE_CLIENT_SORT_STRING);
            }
        }

        /// <summary>
        /// Gets the SourceCourseCallNumber property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SourceCourseCallNumber
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SOURCE_COURSE_CALL_NUMBER);
            }
        }

        /// <summary>
        /// Gets the SourceCourseId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
        /// </summary>
        public static string SourceCourseId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_SOURCE_COURSE_ID);
            }
        }
        
        /// <summary>
        /// Gets the AssociatedEPOrganization property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string AssociatedEPOrganization
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_ASSOCIATED_EP_ORGANIZATION);
            }
        }

        /// <summary>
        /// Gets the CourseActualStartDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string CourseActualStartDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_COURSE_ACTUAL_START_DATE);
            }
        }

        /// <summary>
        /// Gets the CourseActualEndDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string CourseActualEndDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_COURSE_ACTUAL_END_DATE);
            }
        }

        /// <summary>
        /// Gets the DropAddPeriodStartDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string DropAddPeriodStartDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DROP_ADD_PERIOD_START_DATE);
            }
        }

        /// <summary>
        /// Gets the DropAddPeriodEndDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string DropAddPeriodEndDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DROP_ADD_PERIOD_END_DATE);
            }
        }

        /// <summary>
        /// Gets the TermId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string TermId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_TERM_ID);
            }
        }

        /// <summary>
        /// Gets the TermSourcedId property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string TermSourcedId
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_TERM_SOURCED_ID);
            }
        }

        /// <summary>
        /// Gets the Name property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string Name
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_NAME);
            }
        }

        /// <summary>
        /// Gets the Description property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string Description
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_DESCRIPTION);
            }
        }

        /// <summary>
        /// Gets the RegistrationStartDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string RegistrationStartDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_REGISTRATION_START_DATE);
            }
        }

        /// <summary>
        /// Gets the RegistrationEndDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string RegistrationEndDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_REGISTRATION_END_DATE);
            }
        }

        /// <summary>
        /// Gets the TermStartDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string TermStartDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_TERM_START_DATE);
            }
        }

        /// <summary>
        /// Gets the TermEndDate property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string TermEndDate
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_TERM_END_DATE);
            }
        }

        /// <summary>
        /// Gets the WithdrawPeriodEndsOn property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string WithdrawPeriodEndsOn
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_WITHDRAW_PERIOD_ENDS_ON);
            }
        }

        /// <summary>
        /// Gets the ClientString property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request and Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
        /// </summary>
        public static string ClientString
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_CLIENT_STRING);
            }
        }

        /// <summary>
        /// Gets the APIUsername property from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Config,  Com.Pearson.Pdn.Learningstudio.SIS.Terms.Config, and Com.Pearson.Pdn.LearningStudio.SIS.Users.Config
        /// </summary>
        public static string APIUsername
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_API_USERNAME);
            }
        }

        /// <summary>
        /// Gets the APIPassword proprty from appSettings; Com.Pearson.Pdn.Learningstudio.SIS.Courses.Config,  Com.Pearson.Pdn.Learningstudio.SIS.Terms.Config, and Com.Pearson.Pdn.LearningStudio.SIS.Users.Config
        /// </summary>
        public static string APIPassword
        {
            get
            {
                return ConfigUtil.GetConfigurationString(CONST_API_PASSWORD);
            }
        }
    }
}
