using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class GetRoomNumber_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenRoomNumberBedsMethodIsCalled()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            accomodationProperty.RoomNumber = 5;         

            // Assert
            Assert.AreEqual(5, accomodationProperty.RoomNumber);
        }
    }
}
