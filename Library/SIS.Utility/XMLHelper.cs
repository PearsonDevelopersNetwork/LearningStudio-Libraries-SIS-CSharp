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
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Utility
{
    /// <summary>
    /// A custom XMLHelper Class
    /// </summary>
    public static class XMLHelper
    {
        /// <summary>
        /// Serializes the XML responses from the LearningStudio SIS APIs
        /// </summary>
        /// <typeparam name="T">The type of API response to serialize</typeparam>
        /// <param name="response">object</param>
        /// <returns><see cref="XElement"/></returns>
        public static XElement ParseXML<T>(object response)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            xs.Serialize(new StringWriter(sb), response);

            XmlReader xr = XmlReader.Create(new StringReader(sb.ToString()));
            XElement xe = XElement.Load(xr);
            return xe;
        }
    }
}
