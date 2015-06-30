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
using System.Configuration;
using System.Xml;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Utility
{
    /// <summary>
    /// This Class retrieves LearningStudio SIS API related appSettings from a Project's config file
    /// </summary>
    public class ConfigUtil
    {
        private static readonly object ConfigLoader = new object();
        static readonly Dictionary<string, string> appSettings = new Dictionary<string, string>();

        /// <summary>
        /// Return the appSettings value from the config file, if not found will return empty string as value
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        public static string GetConfigurationString(string key)
        {
            var value = string.Empty;

            if (!appSettings.ContainsKey(key))
            {
                if (ConfigurationManager.AppSettings != null)
                    value = ConfigurationManager.AppSettings.Get(key);

                lock (ConfigLoader)
                {
                    if (!appSettings.ContainsKey(key))
                        appSettings.Add(key, value);
                }
            }

            return appSettings[key];
        }
    }
}