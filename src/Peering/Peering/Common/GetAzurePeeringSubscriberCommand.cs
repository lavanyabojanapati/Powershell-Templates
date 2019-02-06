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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;

    /// <inheritdoc />
    /// <summary>
    ///     The Get AzureRm Peering subscriber for a carrier.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPeeringSubscriber", DefaultParameterSetName = "List")]
    [OutputType(typeof(PSPeeringSubscriber))]
    public class GetAzurePeeringSubscriberCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the Peering name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of Peering Resource",
            ParameterSetName = "List")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of Peering Resource",
            ParameterSetName = "single")]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = "List")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = "single")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the subscriber name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bandwidth offer. Omit to return all offers",
            ParameterSetName = "single")]
        [ValidateNotNullOrEmpty]
        public virtual string SubscriberName { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var psPeeringions = string.Equals(this.ParameterSetName, "single", StringComparison.OrdinalIgnoreCase)
                                         ? this.GetPeeringSubscribers()
                                         : this.ListPeeringSubscribers();

            this.WriteObject(psPeeringions, true);
        }

        /// <summary>
        /// The get Peering subscribers.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object GetPeeringSubscribers()
        {
            var ic = this.PeeringSubscriberClient.Get(
                this.ResourceGroupName,
                this.PeeringName,
                this.SubscriberName);
            return this.ToPeeringSubscriberPs(ic);
        }

        /// <summary>
        /// The list Peering subscribers.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object ListPeeringSubscribers()
        {
            var psPeeringions = new List<PSPeeringSubscriber>();
            var icList = this.PeeringSubscribersClient.ListByPeering(
                this.ResourceGroupName,
                this.PeeringName);
            foreach (var ic in icList)
            {
                var psLc = this.ToPeeringSubscriberPs(ic);
                psPeeringions.Add(psLc);
            }

            return psPeeringions;
        }
    }
}