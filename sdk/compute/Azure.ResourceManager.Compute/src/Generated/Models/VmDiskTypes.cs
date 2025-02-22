// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> VM disk types which are disallowed. </summary>
    public readonly partial struct VmDiskTypes : IEquatable<VmDiskTypes>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="VmDiskTypes"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VmDiskTypes(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string UnmanagedValue = "Unmanaged";

        /// <summary> None. </summary>
        public static VmDiskTypes None { get; } = new VmDiskTypes(NoneValue);
        /// <summary> Unmanaged. </summary>
        public static VmDiskTypes Unmanaged { get; } = new VmDiskTypes(UnmanagedValue);
        /// <summary> Determines if two <see cref="VmDiskTypes"/> values are the same. </summary>
        public static bool operator ==(VmDiskTypes left, VmDiskTypes right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VmDiskTypes"/> values are not the same. </summary>
        public static bool operator !=(VmDiskTypes left, VmDiskTypes right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VmDiskTypes"/>. </summary>
        public static implicit operator VmDiskTypes(string value) => new VmDiskTypes(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VmDiskTypes other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VmDiskTypes other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
