using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.RegularRoomTests
{
    [TestClass]
    public class SetOnFloor_Should
    {
        [DataTestMethod]
        [DataRow(-1)]        
        public void SetProperOnFloor_WhenInvalidValueIsPassed(int floor)
        {
            // Arrange
            var regularRoom = new RegularRoom(1, 2, false, "Sea", 222, 5);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => regularRoom.OnFloor = floor);
        }
    }
}
