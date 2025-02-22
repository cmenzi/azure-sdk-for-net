// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Name of the policy. The valid value is AccessTimeTracking. This field is currently read only. </summary>
    public readonly partial struct Name : IEquatable<Name>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="Name"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Name(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AccessTimeTrackingValue = "AccessTimeTracking";

        /// <summary> AccessTimeTracking. </summary>
        public static Name AccessTimeTracking { get; } = new Name(AccessTimeTrackingValue);
        /// <summary> Determines if two <see cref="Name"/> values are the same. </summary>
        public static bool operator ==(Name left, Name right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Name"/> values are not the same. </summary>
        public static bool operator !=(Name left, Name right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Name"/>. </summary>
        public static implicit operator Name(string value) => new Name(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Name other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Name other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
