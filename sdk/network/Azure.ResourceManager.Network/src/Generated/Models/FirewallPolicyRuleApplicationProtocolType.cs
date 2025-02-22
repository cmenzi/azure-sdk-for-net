// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The application protocol type of a Rule. </summary>
    public readonly partial struct FirewallPolicyRuleApplicationProtocolType : IEquatable<FirewallPolicyRuleApplicationProtocolType>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="FirewallPolicyRuleApplicationProtocolType"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FirewallPolicyRuleApplicationProtocolType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string HttpValue = "Http";
        private const string HttpsValue = "Https";

        /// <summary> Http. </summary>
        public static FirewallPolicyRuleApplicationProtocolType Http { get; } = new FirewallPolicyRuleApplicationProtocolType(HttpValue);
        /// <summary> Https. </summary>
        public static FirewallPolicyRuleApplicationProtocolType Https { get; } = new FirewallPolicyRuleApplicationProtocolType(HttpsValue);
        /// <summary> Determines if two <see cref="FirewallPolicyRuleApplicationProtocolType"/> values are the same. </summary>
        public static bool operator ==(FirewallPolicyRuleApplicationProtocolType left, FirewallPolicyRuleApplicationProtocolType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FirewallPolicyRuleApplicationProtocolType"/> values are not the same. </summary>
        public static bool operator !=(FirewallPolicyRuleApplicationProtocolType left, FirewallPolicyRuleApplicationProtocolType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyRuleApplicationProtocolType"/>. </summary>
        public static implicit operator FirewallPolicyRuleApplicationProtocolType(string value) => new FirewallPolicyRuleApplicationProtocolType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FirewallPolicyRuleApplicationProtocolType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FirewallPolicyRuleApplicationProtocolType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
