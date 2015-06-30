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
    /// This class holds the CopyCourseSectionRequest properties
    /// </summary>
    public class CopyCourseSectionRequest
    {
        /// <summary>
        /// Gets or Sets the ClientString property
        /// </summary>
        public string ClientString
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or Sets the DestinationClientSortString property
        /// </summary>
        public string DestinationClientSortString
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationCourseCallNumbers property
        /// </summary>
        public string[] DestinationCourseCallNumbers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationDisplayCourseCode property
        /// </summary>
        public string DestinationDisplayCourseCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationSectionDescription property
        /// </summary>
        public string DestinationSectionDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationSectionNumber property
        /// </summary>
        public long DestinationSectionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the DestinationSectionTitle property
        /// </summary>
        public string DestinationSectionTitle
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

        /// <summary>
        /// Gets or Sets the SourceCourseCallNumber property
        /// </summary>
        public string SourceCourseCallNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the SourceCourseId property
        /// </summary>
        public string SourceCourseId
        {
            get;
            set;
        }
    }
}
