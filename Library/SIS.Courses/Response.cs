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

using System.Collections.Generic;
using System.Text;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Courses
{
    /// <summary>
    /// This class holds the CourseService Response properties
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Constructs a new Response
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Gets or Sets the Content property
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the ContentType property
        /// </summary>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the StatusCode property
        /// </summary>
        public string StatusCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the StatusMessage property
        /// </summary>
        public string StatusMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Implements the toString method for use in debugging
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code: ").Append(StatusCode).Append(", ");
            sb.Append("Message: ").Append(StatusMessage).Append(", ");
            sb.Append("Content-Type: ").Append(ContentType).Append(", ");
            sb.Append("Content: ").Append(Content);

            return sb.ToString();
        }
    }
}
