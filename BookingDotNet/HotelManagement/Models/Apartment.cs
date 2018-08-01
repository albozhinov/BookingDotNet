using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    class Apartment : IApartment
    {
        // Fields
        private bool fullyQuipped;
        private int bedrooms;
        private int bathrooms;
        private int onFloor;
        private int capacity;
        private int beds;
        private bool forSmokers;
        private ViewType view;
        private List<IExtra> listOfExtras;

        // Constructors
        public Apartment()
        {

        }

        // Properties
        public bool FullyQuipped => throw new NotImplementedException();

        public int Bedrooms => throw new NotImplementedException();

        public int Bathrooms => throw new NotImplementedException();

        public int OnFloor => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public int Beds => throw new NotImplementedException();

        public bool ForSmokers => throw new NotImplementedException();

        public ViewType View => throw new NotImplementedException();

        public List<IExtra> ListOfExtras => throw new NotImplementedException();

        public decimal BasePrice => throw new NotImplementedException();

        public void AddExtra(IExtra extra)
        {
            throw new NotImplementedException();
        }

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
