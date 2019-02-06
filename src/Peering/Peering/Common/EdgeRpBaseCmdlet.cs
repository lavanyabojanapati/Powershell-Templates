// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Peering;
using Microsoft.Rest.Azure;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    /// <summary>
    /// The EdgeRpBaseCmdlet
    /// </summary>
    public abstract class EdgeRpBaseCmdlet : AzureRMCmdlet
    {
        private IEdgeRpClient peeringClient;

        /// <summary>
        /// The PeeringClient
        /// </summary>
        public IEdgeRpClient PeeringClient
        {
            get
            {
                return this.peeringClient ?? (this.peeringClient =
                                                  AzureSession.Instance.ClientFactory.CreateArmClient<EdgeRpClient>(
                                                      this.DefaultProfile.DefaultContext,
                                                      AzureEnvironment.Endpoint.ResourceManager));
            }

            set
            {
                this.peeringClient = value;
            }
        }

        /// <summary>
        /// Base Cmdlet execute.
        /// </summary>
        /// <exception cref="NetworkCloudException"></exception>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            try
            {
                Execute();
            }
            catch (CloudException ex)
            {
                throw new NetworkCloudException(ex);
            }
        }

        /// <summary>
        /// The base execute method.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// The Get Resource Group.
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns>The resource group name.</returns>
        public static string GetResourceGroup(string resourceId)
        {
            const string ResourceGroup = "resourceGroups";

            var startIndex = resourceId.IndexOf(ResourceGroup, StringComparison.OrdinalIgnoreCase) +
                             ResourceGroup.Length + 1;
            var endIndex = resourceId.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(startIndex, endIndex - startIndex);
        }
    }
}