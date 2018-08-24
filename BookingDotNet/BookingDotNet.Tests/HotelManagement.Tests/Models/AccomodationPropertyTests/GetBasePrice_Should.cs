using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class GetBasePrice_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetBasePriceMethodIsCalled()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222.1M);

            // Assert
            Assert.AreEqual(222.1M, accomodationProperty.BasePrice);
        }
    }
}
