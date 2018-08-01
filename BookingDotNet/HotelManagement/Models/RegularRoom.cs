using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public class RegularRoom : IRegularRoom
    {
        public int OnFloor => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public int Beds => throw new NotImplementedException();

        public bool ForSmokers => throw new NotImplementedException();

        public ViewType View => throw new NotImplementedException();

        public List<IExtra> ListOfExtras => throw new NotImplementedException();

        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
