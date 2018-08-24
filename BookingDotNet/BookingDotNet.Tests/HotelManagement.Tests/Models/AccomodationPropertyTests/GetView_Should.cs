using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class GetView_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetViewMethodIsCalled()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            // Assert
            Assert.AreEqual(ViewType.Sea, accomodationProperty.View);
        }
    }
}
