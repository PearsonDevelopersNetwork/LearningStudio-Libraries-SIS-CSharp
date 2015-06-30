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
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Com.Pearson.Pdn.Learningstudio.SIS.Users.WCFHelper
{
    /// <summary>
    /// Custom IEndpointBehavior class used to override the default WCF endpoint behavior.
    /// This is required for interoperability between a WCF Client and a WSE 2.0 Service that
    /// implements UsernameToken security using a PasswordDiget.
    /// </summary>
    public class InspectorBehavior : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets the custom ClientInspector.
        /// </summary>
        public ClientInspector ClientInspector
        {
            get; set;
        }

        /// <summary>
        /// Constructs a new InspectorBehavior
        /// </summary>
        /// <param name="clientInspector"><see cref="ClientInspector"/></param>
        public InspectorBehavior(ClientInspector clientInspector)
        {
            ClientInspector = clientInspector;
        }

        /// <summary>
        /// Implement to confirm that the endpoint meets some intended criteria.
        /// </summary>
        /// <param name="endpoint"><see cref="ServiceEndpoint"/></param>
        public void Validate(ServiceEndpoint endpoint)
        {
            // not calling the base implementation
        }

        /// <summary>
        /// Implement to pass data at runtime to bindings to support custom behavior.
        /// </summary>
        /// <param name="endpoint"><see cref="ServiceEndpoint"/></param>
        /// <param name="bindingParameters"><see cref="BindingParameterCollection"/></param>
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // not calling the base implementation
        }

        /// <summary>
        /// Implements a modification or extension of the service across an endpoint.
        /// </summary>
        /// <param name="endponit"><see cref="ServiceEndpoint"/></param>
        /// <param name="endpointDispatcher"><see cref="EndpointDispatcher"/></param>
        public void ApplyDispatchBehavior(ServiceEndpoint endponit, EndpointDispatcher endpointDispatcher)
        {
            // not calling the base implementation
        }

        /// <summary>
        /// Implements the custom modification of the WCF client across an endpoint.
        /// </summary>
        /// <param name="endpoint"><see cref="ServiceEndpoint"/></param>
        /// <param name="clientRuntime"><see cref="ClientRuntime"/></param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            if (this.ClientInspector == null)
                throw new InvalidOperationException("Caller must supply ClientInspector.");

            clientRuntime.ClientMessageInspectors.Add(ClientInspector);
        }
    }
}
