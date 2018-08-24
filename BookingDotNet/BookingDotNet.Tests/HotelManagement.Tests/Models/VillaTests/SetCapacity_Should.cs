﻿using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.VillaTests
{
    [TestClass]
    public class SetCapacity_Should
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(9)]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(int capacity)
        {
            // Arrange
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => villa.Capacity = capacity);
        }
    }
}
