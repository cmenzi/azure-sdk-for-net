// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> ExpressRouteLink child resource definition. </summary>
    public partial class ExpressRouteLink : WritableSubResource
    {
        /// <summary> Initializes a new instance of ExpressRouteLink. </summary>
        public ExpressRouteLink()
        {
        }

        /// <summary> Initializes a new instance of ExpressRouteLink. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> Name of child port resource that is unique among child port resources of the parent. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="routerName"> Name of Azure router associated with physical port. </param>
        /// <param name="interfaceName"> Name of Azure router interface. </param>
        /// <param name="patchPanelId"> Mapping between physical port to patch panel port. </param>
        /// <param name="rackId"> Mapping of physical patch panel to rack. </param>
        /// <param name="connectorType"> Physical fiber port type. </param>
        /// <param name="adminState"> Administrative state of the physical port. </param>
        /// <param name="provisioningState"> The provisioning state of the express route link resource. </param>
        /// <param name="macSecConfig"> MacSec configuration. </param>
        internal ExpressRouteLink(string id, string name, string etag, string routerName, string interfaceName, string patchPanelId, string rackId, ExpressRouteLinkConnectorType? connectorType, ExpressRouteLinkAdminState? adminState, ProvisioningState? provisioningState, ExpressRouteLinkMacSecConfig macSecConfig) : base(id)
        {
            Name = name;
            Etag = etag;
            RouterName = routerName;
            InterfaceName = interfaceName;
            PatchPanelId = patchPanelId;
            RackId = rackId;
            ConnectorType = connectorType;
            AdminState = adminState;
            ProvisioningState = provisioningState;
            MacSecConfig = macSecConfig;
        }

        /// <summary> Name of child port resource that is unique among child port resources of the parent. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Name of Azure router associated with physical port. </summary>
        public string RouterName { get; }
        /// <summary> Name of Azure router interface. </summary>
        public string InterfaceName { get; }
        /// <summary> Mapping between physical port to patch panel port. </summary>
        public string PatchPanelId { get; }
        /// <summary> Mapping of physical patch panel to rack. </summary>
        public string RackId { get; }
        /// <summary> Physical fiber port type. </summary>
        public ExpressRouteLinkConnectorType? ConnectorType { get; }
        /// <summary> Administrative state of the physical port. </summary>
        public ExpressRouteLinkAdminState? AdminState { get; set; }
        /// <summary> The provisioning state of the express route link resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> MacSec configuration. </summary>
        public ExpressRouteLinkMacSecConfig MacSecConfig { get; set; }
    }
}
