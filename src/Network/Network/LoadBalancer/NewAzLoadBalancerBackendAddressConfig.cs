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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressConfig", SupportsShouldProcess = false), OutputType(typeof(PSLoadBalancerBackendAddress))]
    public partial class NewAzureLoadBalancerBackendAddress : NetworkBaseCmdlet
    {
        [Parameter(Mandatory = true,HelpMessage = "The IPAddress to add to the backend pool",ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string IpAddress { get; set; }

        [Parameter(Mandatory = true,HelpMessage = "The name of the Backend Address config",ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,HelpMessage = "The virtual network associated with Backend Address config",ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!ValidateIpAddress(this.IpAddress))
            {
                throw new PSArgumentException($"Invalid IPAddress : {Properties.Resources.InvalidIPAddress}");
            }

            var loadBalancerBackendAddress = new PSLoadBalancerBackendAddress();
            
            // resource id reference needed to add ip address
            if (string.IsNullOrWhiteSpace(this.VirtualNetwork.Id))
            {
                throw new PSArgumentException($"Invalid Virtual Network, ID property empty");
            }

            loadBalancerBackendAddress.VirtualNetwork = this.VirtualNetwork;
            loadBalancerBackendAddress.IpAddress = this.IpAddress;
            loadBalancerBackendAddress.Name = this.Name;

            WriteObject(loadBalancerBackendAddress);
        }

        public bool ValidateIpAddress(string ipAddress)
        {
            IPAddress result = null;

            if (String.IsNullOrEmpty(ipAddress))
            {
                return false; 
            }

            return IPAddress.TryParse(ipAddress, out result);
        }
    }
}