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

namespace Com.Pearson.Pdn.Learningstudio.SIS.Courses.Request
{
    /// <summary>
    /// This class holds the CreateCourseSectionRequest properties
    /// </summary>
    public class CreateCourseSectionRequest
    {
        /// <summary>
        /// Gets or Sets the BillingClassification property
        /// </summary>
        public API.BillingClassificationType BillingClassification
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
        /// Gets or Sets the PrimaryClientSortString property
        /// </summary>
        public string PrimaryClientSortString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationCourseCallNumber property
        /// </summary>
        public string DestinationCourseCallNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DisplayCourseCode property
        /// </summary>
        public string DisplayCourseCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the SectionDescription property
        /// </summary>
        public string SectionDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the SectionNumber property
        /// </summary>
        public long SectionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the SectionTitle property
        /// </summary>
        public string SectionTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationTermSourcedId property
        /// </summary>
        public string DestinationTermSourcedId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationTermId property
        /// </summary>
        public string DestinationTermId
        {
            get;
            set;
        }
    }
}
