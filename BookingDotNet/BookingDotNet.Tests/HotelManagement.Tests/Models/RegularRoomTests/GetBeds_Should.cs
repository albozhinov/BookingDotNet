using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.RegularRoomTests
{
    [TestClass]
    public class GetBeds_Should
    {
        [TestMethod]        
        public void ReturnTheProperValue_WhenGetBedsMethodIsCalled()
        {
            // Arrange & Act
            var regularRoom = new RegularRoom(1, 2, false, "Sea", 222, 5);

            // Assert
            Assert.AreEqual(2, regularRoom.Beds);
        }
    }
}
