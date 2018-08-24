using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class SetView_Should
    {
        [DataTestMethod]
        [DataRow("Swimming pool")]
        [DataRow("Gosho")]
        [DataRow("Pesho")]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(string view)
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new AccomodationPropertyMock(1, 2, false, view, 222));
        }
    }
}
