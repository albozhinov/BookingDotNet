using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public abstract class AccomodationProperty : IAccomodationProperty
    {
        public int Capacity => throw new NotImplementedException();

        public int Beds => throw new NotImplementedException();

        public bool ForSmokers => throw new NotImplementedException();

        public ViewType View => throw new NotImplementedException();

        public List<RegularExtras> ListOfExtras => throw new NotImplementedException();

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
