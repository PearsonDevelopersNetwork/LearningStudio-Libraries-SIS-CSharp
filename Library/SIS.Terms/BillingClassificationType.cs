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

namespace Com.Pearson.Pdn.Learningstudio.SIS.Terms
{
    /// <summary>
    /// Term Billing Types
    /// </summary>
    public enum BillingClassificationType
    {
        /// <summary>
        /// Course is 100% on line.
        /// </summary>
        ECourse,

        /// <summary>
        /// License for a course that is 100% on line.
        /// </summary>
        ECourseLicense,

        /// <summary>
        /// Course is 50% or less online.
        /// </summary>
        ECompanion,

        /// <summary>
        /// LIcense for a course that is 50% or less online.
        /// </summary>
        ECompanionLicense,

        /// <summary>
        /// Course is 50 / 50 between online / onground.
        /// </summary>
        Hybrid,

        /// <summary>
        /// License for a course 50 / 50 between online / onground.
        /// </summary>
        LicenseHybrid,

        /// <summary>
        /// Mixed billing type.
        /// </summary>
        Mixed,

        /// <summary>
        /// Non revenue billing type.
        /// </summary>
        NonRevenue,

        /// <summary>
        /// Evaluation billing type.
        /// </summary>
        Evaluation
    }
}
