using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    class Villa : IVilla
    {
        private int numberOfFloors;
        private int bedrooms;
        private int bathrooms;
        private int capacity;
        private int beds;
        private bool forSmokers;
        private ViewType view;
        private List<IExtra> listOfExtras;

        public Villa(int numberOfFloors, int bedrooms, int bathrooms, int capacity, int beds, bool forSmokers,
            ViewType view, List<IExtra> listOfExtras)
        {

        }



        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
