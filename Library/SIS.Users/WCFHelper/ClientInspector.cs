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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Users.WCFHelper
{
    /// <summary>
    /// Custom IClientMessageInspector class used to override the default WCF Message behavior.
    /// This is required for interoperability between a WCF Client and a WSE 2.0 Service that
    /// implements UsernameToken security using a PasswordDiget.
    /// </summary>
    public class ClientInspector : IClientMessageInspector
    {
        /// <summary>
        /// Gets or sets the custom MessageHeader.
        /// </summary>
        public MessageHeader[] Headers
        {
            get; set;
        }

        /// <summary>
        /// Constructs a new ClientInspector
        /// </summary>
        /// <param name="headers"><see cref="MessageHeader"/></param>
        public ClientInspector(params MessageHeader[] headers)
        {
            Headers = headers;
        }

        /// <summary>
        /// Enables inspection or modification of a message before a request message is sent to a service.
        /// </summary>
        /// <param name="request"><see cref="Message"/></param>
        /// <param name="channel"><see cref="IClientChannel"/></param>
        /// <returns></returns>
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (Headers != null)
            {
                for (int i = Headers.Length - 1; i >= 0; i--)
                    request.Headers.Insert(0, Headers[i]);
            }

            return request;
        }
        
        /// <summary>
        /// Enables inspection or modification of a message after a reply message is received but 
        /// prior to passing it back to the client.
        /// </summary>
        /// <param name="reply"><see cref="Message"/></param>
        /// <param name="correlationState">object</param>
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // not calling the base implementation
        }
    }
}
