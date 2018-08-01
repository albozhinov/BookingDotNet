using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    class Villa : IVilla
    {
        private int NumberOfFloors;

        private int Bedrooms ;

        private int Bathrooms ;

        private int Capacity ;

        private int Beds ;

        private bool ForSmokers ;

        private ViewType View ;

        private List<RegularExtras> ListOfExtras ;

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
