using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.VillaTests
{
    [TestClass]
    public class GetBedrooms_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetBedroomsMethodIsCalled()
        {
            // Arrange & Act 
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);

            // Assert
            Assert.AreEqual(2, villa.Bedrooms);
        }
    }
}
