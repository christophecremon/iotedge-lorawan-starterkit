﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LoRaWan.NetworkServer.Test
{
    using LoRaTools.Regions;
    using LoRaWan.NetworkServer;
    using Xunit;

    public class ChangeTrackingPropertyTest
    {
        [Fact]
        public void When_Using_Enums()
        {
            var target = new ChangeTrackingProperty<LoRaRegionEnum>(nameof(LoRaRegionEnum));
            Assert.False(target.IsDirty());

            target.Set(LoRaRegionEnum.EU868);
            Assert.Equal(LoRaRegionEnum.EU868, target);
            Assert.Equal(LoRaRegionEnum.EU868, target.Get());
            Assert.True(target.IsDirty());
            target.AcceptChanges();
            Assert.False(target.IsDirty());

            target.Set(LoRaRegionEnum.US915);
            Assert.Equal(LoRaRegionEnum.US915, target);
            Assert.Equal(LoRaRegionEnum.US915, target.Get());
            Assert.True(target.IsDirty());
            target.Rollback();
            Assert.False(target.IsDirty());
            Assert.Equal(LoRaRegionEnum.EU868, target);
            Assert.Equal(LoRaRegionEnum.EU868, target.Get());
        }

        [Fact]
        public void When_Using_Strings()
        {
            var target = new ChangeTrackingProperty<string>("Text");
            Assert.False(target.IsDirty());

            target.Set("1");
            Assert.Equal("1", target);
            Assert.Equal("1", target.Get());
            Assert.True(target.IsDirty());
            target.AcceptChanges();
            Assert.False(target.IsDirty());

            target.Set("2");
            Assert.Equal("2", target);
            Assert.Equal("2", target.Get());
            Assert.True(target.IsDirty());
            target.Rollback();
            Assert.False(target.IsDirty());
            Assert.Equal("1", target);
            Assert.Equal("1", target.Get());
        }

        [Fact]
        public void When_Using_Integers()
        {
            var target = new ChangeTrackingProperty<int>("Integer");
            Assert.False(target.IsDirty());

            target.Set(1);
            Assert.Equal(1, target);
            Assert.Equal(1, target.Get());
            Assert.True(target.IsDirty());
            target.AcceptChanges();
            Assert.False(target.IsDirty());

            target.Set(2);
            Assert.Equal(2, target);
            Assert.Equal(2, target.Get());
            Assert.True(target.IsDirty());
            target.Rollback();
            Assert.False(target.IsDirty());
            Assert.Equal(1, target);
            Assert.Equal(1, target.Get());
        }
    }
}
