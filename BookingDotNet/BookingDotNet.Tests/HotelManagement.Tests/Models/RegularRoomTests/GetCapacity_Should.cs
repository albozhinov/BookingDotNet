using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.RegularRoomTests
{
    [TestClass]
    public class GetCapacity_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetCapacityMethodIsCalled()
        {
            // Arrange & Act
            var regularRoom = new RegularRoom(1, 2, false, "Sea", 222, 5);

            // Assert
            Assert.AreEqual(1, regularRoom.Capacity);
        }
    }
}
