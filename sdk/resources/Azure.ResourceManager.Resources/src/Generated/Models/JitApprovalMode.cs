// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The Jit approval mode. </summary>
    public readonly partial struct JitApprovalMode : IEquatable<JitApprovalMode>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="JitApprovalMode"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public JitApprovalMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotSpecifiedValue = "NotSpecified";
        private const string AutoApproveValue = "AutoApprove";
        private const string ManualApproveValue = "ManualApprove";

        /// <summary> NotSpecified. </summary>
        public static JitApprovalMode NotSpecified { get; } = new JitApprovalMode(NotSpecifiedValue);
        /// <summary> AutoApprove. </summary>
        public static JitApprovalMode AutoApprove { get; } = new JitApprovalMode(AutoApproveValue);
        /// <summary> ManualApprove. </summary>
        public static JitApprovalMode ManualApprove { get; } = new JitApprovalMode(ManualApproveValue);
        /// <summary> Determines if two <see cref="JitApprovalMode"/> values are the same. </summary>
        public static bool operator ==(JitApprovalMode left, JitApprovalMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="JitApprovalMode"/> values are not the same. </summary>
        public static bool operator !=(JitApprovalMode left, JitApprovalMode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="JitApprovalMode"/>. </summary>
        public static implicit operator JitApprovalMode(string value) => new JitApprovalMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is JitApprovalMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(JitApprovalMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
