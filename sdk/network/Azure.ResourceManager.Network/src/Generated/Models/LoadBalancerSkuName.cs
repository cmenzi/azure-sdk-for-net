// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Name of a load balancer SKU. </summary>
    public readonly partial struct LoadBalancerSkuName : IEquatable<LoadBalancerSkuName>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="LoadBalancerSkuName"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LoadBalancerSkuName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BasicValue = "Basic";
        private const string StandardValue = "Standard";
        private const string GatewayValue = "Gateway";

        /// <summary> Basic. </summary>
        public static LoadBalancerSkuName Basic { get; } = new LoadBalancerSkuName(BasicValue);
        /// <summary> Standard. </summary>
        public static LoadBalancerSkuName Standard { get; } = new LoadBalancerSkuName(StandardValue);
        /// <summary> Gateway. </summary>
        public static LoadBalancerSkuName Gateway { get; } = new LoadBalancerSkuName(GatewayValue);
        /// <summary> Determines if two <see cref="LoadBalancerSkuName"/> values are the same. </summary>
        public static bool operator ==(LoadBalancerSkuName left, LoadBalancerSkuName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LoadBalancerSkuName"/> values are not the same. </summary>
        public static bool operator !=(LoadBalancerSkuName left, LoadBalancerSkuName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LoadBalancerSkuName"/>. </summary>
        public static implicit operator LoadBalancerSkuName(string value) => new LoadBalancerSkuName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LoadBalancerSkuName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LoadBalancerSkuName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
