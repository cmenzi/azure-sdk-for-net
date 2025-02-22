﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubBufferedProducerClientOptions"/>
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubBufferedProducerClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumWaitTime = TimeSpan.FromSeconds(2),
                MaximumEventBufferLength = 3000,
                EnableIdempotentRetries = true,
                MaximumConcurrentSendsPerPartition = 5,
                Identifier = "Test-Options",
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier should match.");
            Assert.That(clone.EnableIdempotentRetries, Is.EqualTo(options.EnableIdempotentRetries), "The flag to enable idempotent publishing should have been copied.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
            Assert.That(clone.MaximumConcurrentSendsPerPartition, Is.EqualTo(options.MaximumConcurrentSendsPerPartition), "The number of concurrent sends to a partition should have been copied.");
            Assert.That(clone.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The maximum wait time should have been copied.");
            Assert.That(clone.MaximumEventBufferLength, Is.EqualTo(options.MaximumEventBufferLength), "The maximum event buffer length should have been copied.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneKnowsAllMembersOfEventHubBufferedProducerClientOptions()
        {
            // This approach is inelegant and brute force, but allows us to detect
            // additional members added to the annotated message that we're not currently
            // cloning and avoid drift, since Azure.Core.Amqp is an external dependency.

            var knownMembers = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Identifier",
                "EnableIdempotentRetries",
                "ConnectionOptions",
                "RetryOptions",
                "MaximumConcurrentSendsPerPartition",
                "MaximumWaitTime",
                "MaximumEventBufferLength"
            };

            var getterSetterProperties = typeof(EventHubBufferedProducerClientOptions)
                .GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in getterSetterProperties)
            {
                Assert.That(knownMembers.Contains(property.Name), $"The property: { property.Name } of EventHubBufferedProducerClientOptions is not being cloned.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        ///
        [Test]
        public void MaximumConcurrentSendsPerPartitionTooLarge()
        {
            var options = new EventHubBufferedProducerClientOptions();
            Assert.That(() => options.MaximumConcurrentSendsPerPartition = 101, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        [Test]
        public void MaximumConcurrentSendsPerPartitionZeroOutOfRange()
        {
            var options = new EventHubBufferedProducerClientOptions();
            Assert.That(() => options.MaximumConcurrentSendsPerPartition = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.MaximumConcurrentSendsPerPartition"/>
        ///   property.
        /// </summary>
        [Test]
        public void MaximumConcurrentSendsPerPartitionNegativeOutOfRange()
        {
            var options = new EventHubBufferedProducerClientOptions();
            Assert.That(() => options.MaximumConcurrentSendsPerPartition = -1, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventHubBufferedProducerClientOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventHubBufferedProducerClientOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClientOptions.ToEventHubProducerClientOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ToEventHubProducerClientOptionsProducesAValidInstance()
        {
            var options = new EventHubBufferedProducerClientOptions
            {
                MaximumWaitTime = TimeSpan.FromSeconds(2),
                MaximumEventBufferLength = 3000,
                EnableIdempotentRetries = true,
                MaximumConcurrentSendsPerPartition = 5,
                Identifier = "Test-Options",
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            var transformedOptions = options.ToEventHubProducerClientOptions();

            Assert.That(transformedOptions.Identifier, Is.EqualTo(options.Identifier), "The identifier should match.");
            Assert.That(transformedOptions.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(transformedOptions.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(transformedOptions.EnableIdempotentPartitions, Is.EqualTo(options.EnableIdempotentRetries), "Idempotent partitions should be the same as idempotent retries.");
        }
    }
}
