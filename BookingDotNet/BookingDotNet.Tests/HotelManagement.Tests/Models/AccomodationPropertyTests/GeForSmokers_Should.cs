using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class GeForSmokers_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetForSmokersMethodIsCalled()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            // Assert
            Assert.AreEqual(false, accomodationProperty.ForSmokers);
        }       
    }
}
