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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     New Azure Peering Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzPeeringPrefix",
        DefaultParameterSetName = Constants.ParameterSetNamePrefixByPeering)]
    [OutputType(typeof(PSPeeringPrefix))]
    public class GetAzurePeeringPrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets the Peering name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefixByPeering)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefixByPrefixName)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        ///     Gets or sets the resource group name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefixByPeering)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefixByPrefixName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the prefix name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.PrefixNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefixByPrefixName)]
        [ValidateNotNullOrEmpty]
        public virtual string PrefixName { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var psPeeringions = string.Equals(
                                         this.ParameterSetName,
                                         Constants.ParameterSetNamePrefixByPrefixName,
                                         StringComparison.OrdinalIgnoreCase)
                                         ? this.GetPeeringPrefix()
                                         : this.ListPeeringPrefixes();

            this.WriteObject(psPeeringions, true);
        }

        private object GetPeeringPrefix()
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeeringPrefix>(
                this.PeeringPrefixesClient.Get(this.ResourceGroupName, this.PeeringName, this.PrefixName));
        }

        /// <summary>
        ///     The get prefixes.
        /// </summary>
        /// <returns>
        ///     The <see cref="PeeringPrefix" />.
        /// </returns>
        private object ListPeeringPrefixes()
        {
            var icList = this.PrefixesClient.ListByPeering(
                this.ResourceGroupName,
                this.PeeringName);

            return icList.Select(x => PeeringResourceManagerProfile.Mapper.Map<PSPeeringPrefix>(x)).ToList();
        }
    }
}