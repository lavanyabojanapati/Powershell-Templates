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
    using System.Management.Automation;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     New Azure Peering Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmPeeringPrefix", DefaultParameterSetName = Constants.ParameterSetNamePrefix)]
    [OutputType(typeof(PSPeeringPrefix))]
    public class NewAzureRmPeeringPrefix : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets the Peering name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionPeeringName,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefix)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }
        
        /// <summary>
        ///     Gets or sets the resource group name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionResourceGroupName,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefix)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PrefixHelp,
            ParameterSetName = Constants.ParameterSetNamePrefix)]
        [ValidateNotNullOrEmpty]
        public virtual string Prefix { get; set; }

        /// <summary>
        ///     Gets or sets the prefix name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PrefixNameHelp,
            ParameterSetName = Constants.ParameterSetNamePrefix)]
        [ValidateNotNullOrEmpty]
        public virtual string PrefixName { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.WriteObject(this.CreatePeeringPrefix());
        }

        /// <summary>
        ///     The create Peering prefix.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeeringPrefix" />.
        /// </returns>
        private PSPeeringPrefix CreatePeeringPrefix()
        {
            var PeeringPrefix = new PSPeeringPrefix
                                         {
                                             Prefix = this.Prefix
                                         };
            try
            {
                this.PeeringPrefixesClient.CreateOrUpdate(
                    this.ResourceGroupName,
                    this.PeeringName,
                    this.PrefixName,
                    PeeringResourceManagerProfile.Mapper.Map<PeeringPrefix>(PeeringPrefix));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringPrefix>(
                    this.PeeringPrefixesClient.Get(
                        this.ResourceGroupName,
                        this.PeeringName,
                        this.PrefixName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}