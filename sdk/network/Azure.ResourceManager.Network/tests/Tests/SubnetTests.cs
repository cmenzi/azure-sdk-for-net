﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class SubnetTests : NetworkServiceClientTestBase
    {
        public SubnetTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [Test]
        [RecordedTest]
        public async Task SubnetApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnet1Name = Recording.GenerateAssetName("azsmnet");
            string subnet2Name = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.0.0.0/24", } }
            };

            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnetName, vnet);
            var vnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            // Create a Subnet
            // Populate paramters for a Subnet
            var subnet = new SubnetData()
            {
                Name = subnet2Name,
                AddressPrefix = "10.0.1.0/24",
            };

            #region Verification
            var putSubnetResponseOperation = await vnetResponse.Value.GetSubnets().CreateOrUpdateAsync(subnet2Name, subnet);
            await putSubnetResponseOperation.WaitForCompletionAsync();;
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkContainer.GetAsync(vnetName);
            Assert.AreEqual(2, getVnetResponse.Value.Data.Subnets.Count());

            Response<Subnet> getSubnetResponse = await vnetResponse.Value.GetSubnets().GetAsync(subnet2Name);

            // Verify the getSubnetResponse
            Assert.True(AreSubnetsEqual(getVnetResponse.Value.Data.Subnets[1], getSubnetResponse.Value.Data));

            AsyncPageable<Subnet> getSubnetListResponseAP = vnetResponse.Value.GetSubnets().GetAllAsync();
            List<Subnet> getSubnetListResponse = await getSubnetListResponseAP.ToEnumerableAsync();
            // Verify ListSubnets
            Assert.True(AreSubnetListsEqual(getVnetResponse.Value.Data.Subnets, getSubnetListResponse));

            // Delete the subnet "subnet1"
            await getSubnetResponse.Value.DeleteAsync();

            // Verify that the deletion was successful
            getSubnetListResponseAP = vnetResponse.Value.GetSubnets().GetAllAsync();
            getSubnetListResponse = await getSubnetListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getSubnetListResponse);
            Assert.AreEqual(subnet1Name, getSubnetListResponse.ElementAt(0).Data.Name);
            #endregion
        }

        [Test]
        [RecordedTest]
        [Ignore("Track2: Need  RedisManagementClient")]
        public async Task SubnetResourceNavigationLinksTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkContainer.CreateOrUpdateAsync(vnetName, vnet);
            var vnetResponse = await putVnetResponseOperation.WaitForCompletionAsync();;
            Response<Subnet> getSubnetResponse = await vnetResponse.Value.GetSubnets().GetAsync(subnetName);
            Assert.Null(getSubnetResponse.Value.Data.ResourceNavigationLinks);

            //TODO:Need RedisManagementClient
            //redisClient.Redis.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, redisName, parameters: new RedisCreateOrUpdateParameters
            //{
            //    Location = location,
            //    Sku = new Microsoft.Azure.Management.Redis.Models.Sku()
            //    {
            //        Name = SkuName.Premium,
            //        Family = SkuFamily.P,
            //        Capacity = 1
            //    },
            //    SubnetId = getSubnetResponse.Id
            //}).Wait();

            // wait for maximum 30 minutes for cache to create
            //for (int i = 0; i < 60; i++)
            //{
            //    TestUtilities.Wait(new TimeSpan(0, 0, 30));
            //    RedisResource responseGet = redisClient.Redis.Get(resourceGroupName: resourceGroupName, name: redisName);
            //    if ("succeeded".Equals(responseGet.ProvisioningState, StringComparison.OrdinalIgnoreCase))
            //    {
            //        break;
            //    }
            //    Assert.False(i == 60, "Cache is not in succeeded state even after 30 min.");
            //}

            getSubnetResponse = await vnetResponse.Value.GetSubnets().GetAsync(subnetName);
            Assert.AreEqual(1, getSubnetResponse.Value.Data.ResourceNavigationLinks.Count);
        }

        private bool AreSubnetsEqual(SubnetData subnet1, SubnetData subnet2)
        {
            return subnet1.Id == subnet2.Id &&
                   subnet1.Etag == subnet2.Etag &&
                   subnet1.ProvisioningState == subnet2.ProvisioningState &&
                   subnet1.Name == subnet2.Name &&
                   subnet1.AddressPrefix == subnet2.AddressPrefix;
        }

        private bool AreSubnetListsEqual(IEnumerable<SubnetData> subnets1, IEnumerable<Subnet> subnets2)
        {
            var subnetCollection = subnets1.Zip(subnets2, (s1, s2) => new { subnet1 = s1, subnet2 = s2.Data });

            return subnetCollection.All(subnets => AreSubnetsEqual(subnets.subnet1, subnets.subnet2));
        }
    }
}
