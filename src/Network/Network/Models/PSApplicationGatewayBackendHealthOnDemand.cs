using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSApplicationGatewayBackendHealthOnDemand
    {
        public PSApplicationGatewayBackendAddressPool BackendAddressPool { get; set; }
        public PSApplicationGatewayBackendHealthHttpSettings BackendHealthHttpSettings { get; set; }
    }
}
