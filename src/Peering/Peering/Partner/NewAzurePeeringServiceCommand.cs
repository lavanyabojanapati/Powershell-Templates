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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering
{
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    ///     New Azure Peering Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzPeeringService", DefaultParameterSetName = Constants.PeeringService)]
    [OutputType(typeof(PSPeering))]
    public class NewAzurePeeringServiceCommand : PeeringBaseCmdlet
    {
        private PSPeeringPropertiesPartner propertiesPartner = new PSPeeringPropertiesPartner();

        /// <summary>
        /// Gets or sets the Peering name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionPeeringName,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.PeeringService)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringName { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionResourceGroupName,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.PeeringService)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the Peering location.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.PeeringService)]
        [ValidateNotNullOrEmpty]
        public virtual string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the carrier name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of Known Partner",
            ParameterSetName = Constants.PeeringService)]
        [ValidateNotNullOrEmpty]
        public virtual string CarrierName { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var PeeringRequest = this.CreatePeering();
            this.WriteObject(PeeringRequest);
        }

        private PSPeering CreatePeering()
        {
            var PeeringRequest = new PSPeering(name: this.PeeringName, location: this.GetAzureRegion(this.PeeringLocation, Constants.Partner));

            PeeringRequest.PeeringLocation = this.PeeringLocation;
            if (this.ParameterSetName.Contains(Constants.PeeringService))
            {
                this.propertiesPartner.PartnerName = this.CarrierName;
                PeeringRequest.Partner = this.propertiesPartner;
                PeeringRequest.Kind = Constants.Partner;
            }
            else
            {
                Console.WriteLine($"PSPeering {this.ParameterSetName} is not recognized Try Again");
            }

            var psSku = new PSPeeringSku();
            psSku.Name = Constants.PremiumPartnerMetered;
            PeeringRequest.Sku = psSku;

            try
            {
                var Peering = PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(PeeringRequest);
                this.PeeringClient.CreateOrUpdate(this.ResourceGroupName, PeeringRequest.Name, Peering);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Request URL: {ex.Message} Content: {ex.Data}");
            }

            try
            {
                this.ToPeeringPs(PeeringRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Unable to retrieve stored Peering from EdgeRp, state was not persisted",
                    ex.InnerException);
            }

            return PeeringRequest;
        }
    }
}