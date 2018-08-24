using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class SetBeds_Should
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(11)]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(int beds)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.Beds = beds);
        }
    }
}
