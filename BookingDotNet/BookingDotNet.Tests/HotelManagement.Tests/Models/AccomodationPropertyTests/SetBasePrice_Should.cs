using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class SetBasePrice_Should
    {
        [DataTestMethod]
        [DataRow("49.99999")]
        [DataRow("400.1111111")]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(string basePrice)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222M);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.BasePrice = decimal.Parse(basePrice));
        }
    }
}
