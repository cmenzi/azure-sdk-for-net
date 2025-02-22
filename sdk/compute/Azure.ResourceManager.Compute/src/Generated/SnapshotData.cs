// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing the Snapshot data model. </summary>
    public partial class SnapshotData : TrackedResource
    {
        /// <summary> Initializes a new instance of SnapshotData. </summary>
        /// <param name="location"> The location. </param>
        public SnapshotData(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SnapshotData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="managedBy"> Unused. Always Null. </param>
        /// <param name="sku"> The snapshots sku name. Can be Standard_LRS, Premium_LRS, or Standard_ZRS. This is an optional parameter for incremental snapshot and the default behavior is the SKU will be set to the same sku as the previous snapshot. </param>
        /// <param name="extendedLocation"> The extended location where the snapshot will be created. Extended location cannot be changed. </param>
        /// <param name="timeCreated"> The time when the snapshot was created. </param>
        /// <param name="osType"> The Operating System type. </param>
        /// <param name="hyperVGeneration"> The hypervisor generation of the Virtual Machine. Applicable to OS disks only. </param>
        /// <param name="purchasePlan"> Purchase plan information for the image from which the source disk for the snapshot was originally created. </param>
        /// <param name="creationData"> Disk source information. CreationData information cannot be changed after the disk has been created. </param>
        /// <param name="diskSizeGB"> If creationData.createOption is Empty, this field is mandatory and it indicates the size of the disk to create. If this field is present for updates or creation with other options, it indicates a resize. Resizes are only allowed if the disk is not attached to a running VM, and can only increase the disk&apos;s size. </param>
        /// <param name="diskSizeBytes"> The size of the disk in bytes. This field is read only. </param>
        /// <param name="diskState"> The state of the snapshot. </param>
        /// <param name="uniqueId"> Unique Guid identifying the resource. </param>
        /// <param name="encryptionSettingsCollection"> Encryption settings collection used be Azure Disk Encryption, can contain multiple encryption settings per disk or snapshot. </param>
        /// <param name="provisioningState"> The disk provisioning state. </param>
        /// <param name="incremental"> Whether a snapshot is incremental. Incremental snapshots on the same disk occupy less space than full snapshots and can be diffed. </param>
        /// <param name="encryption"> Encryption property can be used to encrypt data at rest with customer managed keys or platform managed keys. </param>
        /// <param name="networkAccessPolicy"> Policy for accessing the disk via network. </param>
        /// <param name="diskAccessId"> ARM id of the DiskAccess resource for using private endpoints on disks. </param>
        /// <param name="supportsHibernation"> Indicates the OS on a snapshot supports hibernation. </param>
        internal SnapshotData(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, string managedBy, SnapshotSku sku, ExtendedLocation extendedLocation, DateTimeOffset? timeCreated, OperatingSystemTypes? osType, HyperVGeneration? hyperVGeneration, PurchasePlanAutoGenerated purchasePlan, CreationData creationData, int? diskSizeGB, long? diskSizeBytes, DiskState? diskState, string uniqueId, EncryptionSettingsCollection encryptionSettingsCollection, string provisioningState, bool? incremental, Encryption encryption, NetworkAccessPolicy? networkAccessPolicy, string diskAccessId, bool? supportsHibernation) : base(id, name, type, tags, location)
        {
            ManagedBy = managedBy;
            Sku = sku;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            DiskState = diskState;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            Incremental = incremental;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            SupportsHibernation = supportsHibernation;
        }

        /// <summary> Unused. Always Null. </summary>
        public string ManagedBy { get; }
        /// <summary> The snapshots sku name. Can be Standard_LRS, Premium_LRS, or Standard_ZRS. This is an optional parameter for incremental snapshot and the default behavior is the SKU will be set to the same sku as the previous snapshot. </summary>
        public SnapshotSku Sku { get; set; }
        /// <summary> The extended location where the snapshot will be created. Extended location cannot be changed. </summary>
        public ExtendedLocation ExtendedLocation { get; set; }
        /// <summary> The time when the snapshot was created. </summary>
        public DateTimeOffset? TimeCreated { get; }
        /// <summary> The Operating System type. </summary>
        public OperatingSystemTypes? OsType { get; set; }
        /// <summary> The hypervisor generation of the Virtual Machine. Applicable to OS disks only. </summary>
        public HyperVGeneration? HyperVGeneration { get; set; }
        /// <summary> Purchase plan information for the image from which the source disk for the snapshot was originally created. </summary>
        public PurchasePlanAutoGenerated PurchasePlan { get; set; }
        /// <summary> Disk source information. CreationData information cannot be changed after the disk has been created. </summary>
        public CreationData CreationData { get; set; }
        /// <summary> If creationData.createOption is Empty, this field is mandatory and it indicates the size of the disk to create. If this field is present for updates or creation with other options, it indicates a resize. Resizes are only allowed if the disk is not attached to a running VM, and can only increase the disk&apos;s size. </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary> The size of the disk in bytes. This field is read only. </summary>
        public long? DiskSizeBytes { get; }
        /// <summary> The state of the snapshot. </summary>
        public DiskState? DiskState { get; }
        /// <summary> Unique Guid identifying the resource. </summary>
        public string UniqueId { get; }
        /// <summary> Encryption settings collection used be Azure Disk Encryption, can contain multiple encryption settings per disk or snapshot. </summary>
        public EncryptionSettingsCollection EncryptionSettingsCollection { get; set; }
        /// <summary> The disk provisioning state. </summary>
        public string ProvisioningState { get; }
        /// <summary> Whether a snapshot is incremental. Incremental snapshots on the same disk occupy less space than full snapshots and can be diffed. </summary>
        public bool? Incremental { get; set; }
        /// <summary> Encryption property can be used to encrypt data at rest with customer managed keys or platform managed keys. </summary>
        public Encryption Encryption { get; set; }
        /// <summary> Policy for accessing the disk via network. </summary>
        public NetworkAccessPolicy? NetworkAccessPolicy { get; set; }
        /// <summary> ARM id of the DiskAccess resource for using private endpoints on disks. </summary>
        public string DiskAccessId { get; set; }
        /// <summary> Indicates the OS on a snapshot supports hibernation. </summary>
        public bool? SupportsHibernation { get; set; }
    }
}
