using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.VillaTests
{
    [TestClass]
    public class GetBathrooms_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetBathroomsMethodIsCalled()
        {
            // Arrange & Act 
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);

            // Assert
            Assert.AreEqual(3, villa.Bathrooms);
        }
    }
}
