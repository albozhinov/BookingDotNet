using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Common
{
    public interface IExtra
    {
        int Tier { get; }

        AvailableExtras Name { get; }

        decimal Price { get; }
    }
}
