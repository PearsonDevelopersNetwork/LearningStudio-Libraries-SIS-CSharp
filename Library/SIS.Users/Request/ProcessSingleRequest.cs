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
using System.Linq;
using System.Text;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Users.Request
{
    /// <summary>
    /// This class holds the ProcessSingleRequest properties
    /// </summary>
    public class ProcessSingleRequest
    {
        private API.properties properties = new API.properties();

        /// <summary>
        /// Gets or Sets the Source property
        /// </summary>
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Id property
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the LoginId property
        /// </summary>
        public string LoginId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Password property
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the FirstName property
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the MiddleName property
        /// </summary>
        public string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the LastName property
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Gender property
        /// </summary>
        public string Gender
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DOB property
        /// </summary>
        public string DOB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Disability property
        /// </summary>
        public string Disability
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Email property
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the PhoneNumber property
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Address1 property
        /// </summary>
        public string Address1
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or Sets the Address2 property
        /// </summary>
        public string Address2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the City property
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the State property
        /// </summary>
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the ZipCode property
        /// </summary>
        public string ZipCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Country property
        /// </summary>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the ExtendedUserProperties property
        /// </summary>
        public IDictionary<string, string> ExtendedUserProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the CallNumber property
        /// </summary>
        public string CallNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the NodeString property
        /// </summary>
        public string NodeString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the RoleId property
        /// </summary>
        public string RoleId
        {
            get;
            set;
        }

        /// <summary>
        /// Default the Properties Child Element, indicate the Request was created using the Library
        /// </summary>
        public API.properties Properties
        {
            get
            {
                this.properties.datasource = "LS-Library-SIS-CSharp-V1";
                this.properties.datetime = DateTime.UtcNow.ToShortDateString();

                return this.properties;
            }
        }
    }
}