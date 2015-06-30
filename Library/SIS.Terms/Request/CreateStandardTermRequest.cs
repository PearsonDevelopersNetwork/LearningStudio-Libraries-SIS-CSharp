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

namespace Com.Pearson.Pdn.Learningstudio.SIS.Terms.Request
{
    /// <summary>
    /// This class holds the CreateStandardTermRequest properties
    /// </summary>
    public class CreateStandardTermRequest
    {
        /// <summary>
        /// Gets or Sets the AssociatedEPOrganization propertey
        /// </summary>
        public string[] AssociatedEPOrganization
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the BillingClassificationType property
        /// </summary>
        public BillingClassificationType? BillingClassificationType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the ClientString property
        /// </summary>
        public string ClientString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the CourseActualStartDate property
        /// </summary>
        public DateTime CourseActualStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the CourseActualEndDate property
        /// </summary>
        public DateTime CourseActualEndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Description property
        /// </summary>
        public string Description
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or Sets the DropAddPeriodStartDate property
        /// </summary>
        public DateTime DropAddPeriodStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DropAddPeriodEndDate property
        /// </summary>
        public DateTime DropAddPeriodEndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the TermSourcedId property
        /// </summary>
        public string TermSourcedId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the Name property
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the RegistrationStartDate property
        /// </summary>
        public DateTime RegistrationStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the RegistrationEndDate property
        /// </summary>
        public DateTime RegistrationEndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the TermStartDate property
        /// </summary>
        public DateTime TermStartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the TermEndDate property
        /// </summary>
        public DateTime TermEndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the WithdrawPeriodEndsOn property
        /// </summary>
        public DateTime WithdrawPeriodEndsOn
        {
            get;
            set;
        }
    }
}
