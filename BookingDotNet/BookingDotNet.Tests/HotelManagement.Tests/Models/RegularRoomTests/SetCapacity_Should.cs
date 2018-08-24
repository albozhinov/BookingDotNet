using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.RegularRoomTests
{
    [TestClass]
    public class SetCapacity_Should
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(3)]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(int capacity)
        {
            // Arrange
            var regularRoom = new RegularRoom(1, 2,false, "Sea", 222, 5);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => regularRoom.Capacity = capacity);
        }
    }
}
