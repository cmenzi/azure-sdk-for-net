// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> Specifies the mode of VM Guest Patch Assessment for the IaaS virtual machine.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **ImageDefault** - You control the timing of patch assessments on a virtual machine. &lt;br /&gt;&lt;br /&gt; **AutomaticByPlatform** - The platform will trigger periodic patch assessments. The property provisionVMAgent must be true. </summary>
    public readonly partial struct LinuxPatchAssessmentMode : IEquatable<LinuxPatchAssessmentMode>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="LinuxPatchAssessmentMode"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LinuxPatchAssessmentMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ImageDefaultValue = "ImageDefault";
        private const string AutomaticByPlatformValue = "AutomaticByPlatform";

        /// <summary> ImageDefault. </summary>
        public static LinuxPatchAssessmentMode ImageDefault { get; } = new LinuxPatchAssessmentMode(ImageDefaultValue);
        /// <summary> AutomaticByPlatform. </summary>
        public static LinuxPatchAssessmentMode AutomaticByPlatform { get; } = new LinuxPatchAssessmentMode(AutomaticByPlatformValue);
        /// <summary> Determines if two <see cref="LinuxPatchAssessmentMode"/> values are the same. </summary>
        public static bool operator ==(LinuxPatchAssessmentMode left, LinuxPatchAssessmentMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LinuxPatchAssessmentMode"/> values are not the same. </summary>
        public static bool operator !=(LinuxPatchAssessmentMode left, LinuxPatchAssessmentMode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LinuxPatchAssessmentMode"/>. </summary>
        public static implicit operator LinuxPatchAssessmentMode(string value) => new LinuxPatchAssessmentMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LinuxPatchAssessmentMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LinuxPatchAssessmentMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
