// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Output of virtual machine capture operation. </summary>
    public partial class VirtualMachineCaptureResult : WritableSubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineCaptureResult. </summary>
        public VirtualMachineCaptureResult()
        {
            Resources = new ChangeTrackingList<object>();
        }

        /// <summary> Initializes a new instance of VirtualMachineCaptureResult. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="schema"> the schema of the captured virtual machine. </param>
        /// <param name="contentVersion"> the version of the content. </param>
        /// <param name="parameters"> parameters of the captured virtual machine. </param>
        /// <param name="resources"> a list of resource items of the captured virtual machine. </param>
        internal VirtualMachineCaptureResult(string id, string schema, string contentVersion, object parameters, IReadOnlyList<object> resources) : base(id)
        {
            Schema = schema;
            ContentVersion = contentVersion;
            Parameters = parameters;
            Resources = resources;
        }

        /// <summary> the schema of the captured virtual machine. </summary>
        public string Schema { get; }
        /// <summary> the version of the content. </summary>
        public string ContentVersion { get; }
        /// <summary> parameters of the captured virtual machine. </summary>
        public object Parameters { get; }
        /// <summary> a list of resource items of the captured virtual machine. </summary>
        public IReadOnlyList<object> Resources { get; }
    }
}
