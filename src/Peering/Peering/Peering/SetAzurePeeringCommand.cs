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
    using System.Management.Automation;

    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest;

    /// <inheritdoc />
    /// <summary>
    ///     Updates the Peering object.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzPeering")]
    [OutputType(typeof(PSPeering))]
    public class SetAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy Peering.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering,
            DontShow = true)]
        public PSPeering Peering { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute operation.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var PeeringRequest = this.UpdatePeeringOffer();
            this.WriteObject(PeeringRequest);
        }

        /// <summary>
        ///     The update Peering offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdatePeeringOffer()
        {
            var resourceGroupName = this.GetResourceGroupNameFromId(this.Peering.Id);
            var PeeringName = this.GetPeeringNameFromId(this.Peering.Id);
            var Peering = new PSPeering
            {
                Kind = this.Peering.Kind,
                Direct = this.Peering.Direct,
                Exchange = null,
                PeeringLocation = this.Peering.PeeringLocation,
                Location = this.Peering.Location,
                Sku = this.Peering.Sku,
                Partner = null,
                ETag = this.Peering.ETag,
                PeeringState = this.Peering.PeeringState,
                ProvisioningState = this.Peering.ProvisioningState,
                Tags = this.Peering.Tags
            };

            // TODO needs to update not CreateOrUpdate
            try
            {
                this.PeeringClient.CreateOrUpdate(
                    resourceGroupName.ToString(),
                    PeeringName.ToString(),
                    PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(Peering));
            }
            catch (HttpOperationException ex)
            {
                throw new Exception(
                    $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
            }

            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), PeeringName.ToString()));
        }

        /// <summary>
        /// The get Peering.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="PeeringName">
        /// The Peering name.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        private PSPeering GetPeering(string resourceGroupName, string PeeringName)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                this.PeeringClient.Get(resourceGroupName, PeeringName));
        }

    }
}