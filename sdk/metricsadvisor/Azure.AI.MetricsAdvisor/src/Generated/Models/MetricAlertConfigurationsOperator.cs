// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// cross metrics operator
    /// 
    /// should be specified when setting up multiple metric alerting configurations
    /// </summary>
    public readonly partial struct MetricAlertConfigurationsOperator : IEquatable<MetricAlertConfigurationsOperator>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="MetricAlertConfigurationsOperator"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MetricAlertConfigurationsOperator(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AndValue = "AND";
        private const string OrValue = "OR";
        private const string XorValue = "XOR";
        /// <summary> Determines if two <see cref="MetricAlertConfigurationsOperator"/> values are the same. </summary>
        public static bool operator ==(MetricAlertConfigurationsOperator left, MetricAlertConfigurationsOperator right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MetricAlertConfigurationsOperator"/> values are not the same. </summary>
        public static bool operator !=(MetricAlertConfigurationsOperator left, MetricAlertConfigurationsOperator right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MetricAlertConfigurationsOperator"/>. </summary>
        public static implicit operator MetricAlertConfigurationsOperator(string value) => new MetricAlertConfigurationsOperator(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MetricAlertConfigurationsOperator other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MetricAlertConfigurationsOperator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
