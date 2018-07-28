using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Contracts
{
    public interface ICompleteEstate : IAccomodationProperty
    {
        int Bedrooms { get; }
        int Bathrooms { get; }
    }
}
