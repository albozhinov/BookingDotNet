using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.VillaTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetProperNumberOfFloors_WhenTheObjectIsConstructed()
        {
            // int numberOfFloors, int bedrooms, int bathrooms
            // Arrange & Act
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);            
            
            // Assert
            Assert.AreEqual(1, villa.NumberOfFloors);
        }

        [TestMethod]
        public void SetProperBedrooms_WhenTheObjectIsConstructed()
        {            
            // Arrange & Act
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);

            // Assert
            Assert.AreEqual(2, villa.Bedrooms);
        }

        [TestMethod]
        public void SetProperBathroom_WhenTheObjectIsConstructed()
        {            
            // Arrange & Act
            var villa = new Villa(1, 2, 3, 6, 6, false, "Sea", 222);

            // Assert
            Assert.AreEqual(3, villa.Bathrooms);
        }
    }
}
