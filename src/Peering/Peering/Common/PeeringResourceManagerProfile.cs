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

using AutoMapper;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using CNM = Models;
    using MNM = Management.Peering.Models;
    using Profile = AutoMapper.Profile;

    /// <summary>
    /// The network resource manager profile
    /// </summary>
    public class PeeringResourceManagerProfile : Profile
    {
        private static IMapper mapper;

        private static readonly object Lock = new object();

        /// <summary>
        /// The network resource manager mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                lock (Lock)
                {
                    if (mapper == null) Initialize();

                    return mapper;
                }
            }
        }

        /// <summary>
        /// The profile name for Network manager.
        /// </summary>
        public override string ProfileName => "NetworkResourceManagerProfile";

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PeeringResourceManagerProfile>();

                // MNM to CNM 
                cfg.CreateMap<MNM.BgpCommunity, CNM.PSBgpCommunity>();
                cfg.CreateMap<MNM.BgpSession, CNM.PSBgpSession>();
                cfg.CreateMap<MNM.DirectConnection, CNM.PSDirectConnection>();
                cfg.CreateMap<MNM.DirectPeeringFacility, CNM.PSDirectPeeringFacility>();
                cfg.CreateMap<MNM.ExchangeConnection, CNM.PSExchangeConnection>();
                cfg.CreateMap<MNM.ExchangePeeringFacility, CNM.PSExchangePeeringFacility>();
                cfg.CreateMap<MNM.PeeringModel, CNM.PSPeering>();
                cfg.CreateMap<MNM.PeeringBandwidthOffer, CNM.PSPeeringBandwidthOffer>();
                cfg.CreateMap<MNM.PeeringLocation, CNM.PSPeeringLocation>();
                cfg.CreateMap<MNM.PeeringPartner, CNM.PSPeeringPartner>();
                cfg.CreateMap<MNM.PeeringPrefix, CNM.PSPeeringPrefix>();
                cfg.CreateMap<MNM.PeeringPropertiesDirect, CNM.PSPeeringPropertiesDirect>();
                cfg.CreateMap<MNM.PeeringPropertiesPartner, CNM.PSPeeringPropertiesPartner>();
                cfg.CreateMap<MNM.PeeringSku, CNM.PSPeeringSku>();
                cfg.CreateMap<MNM.PeeringSubscriber, CNM.PSPeeringSubscriber>();
                cfg.CreateMap<MNM.ResourceIdentifier, CNM.PSResourceIdentifier>();

                // CNM to MNM
                cfg.CreateMap<CNM.PSBgpCommunity, MNM.BgpCommunity>();
                cfg.CreateMap<CNM.PSBgpSession, MNM.BgpSession>();
                cfg.CreateMap<CNM.PSDirectConnection, MNM.DirectConnection>();
                cfg.CreateMap<CNM.PSDirectPeeringFacility, MNM.DirectPeeringFacility>();
                cfg.CreateMap<CNM.PSExchangeConnection, MNM.ExchangeConnection>();
                cfg.CreateMap<CNM.PSExchangePeeringFacility, MNM.ExchangePeeringFacility>();
                cfg.CreateMap<CNM.PSPeering, MNM.PeeringModel>();
                cfg.CreateMap<CNM.PSPeeringBandwidthOffer, MNM.PeeringBandwidthOffer>();
                cfg.CreateMap<CNM.PSPeeringLocation, MNM.PeeringLocation>();
                cfg.CreateMap<CNM.PSPeeringPartner, MNM.PeeringPartner>();
                cfg.CreateMap<CNM.PSPeeringPrefix, MNM.PeeringPrefix>();
                cfg.CreateMap<CNM.PSPeeringPropertiesDirect, MNM.PeeringPropertiesDirect>();
                cfg.CreateMap<CNM.PSPeeringPropertiesPartner, MNM.PeeringPropertiesPartner>();
                cfg.CreateMap<CNM.PSPeeringSku, MNM.PeeringSku>();
                cfg.CreateMap<CNM.PSPeeringSubscriber, MNM.PeeringSubscriber>();
                cfg.CreateMap<CNM.PSResourceIdentifier, MNM.ResourceIdentifier>();

            });
            mapper = config.CreateMapper();
        }
    }
}