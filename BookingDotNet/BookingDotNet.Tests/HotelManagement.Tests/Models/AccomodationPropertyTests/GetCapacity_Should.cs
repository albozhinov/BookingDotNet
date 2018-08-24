using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class GetCapacity_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetCapacityMethodIsCalled()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            // Assert
            Assert.AreEqual(1, accomodationProperty.Capacity);
        }
    }
}
