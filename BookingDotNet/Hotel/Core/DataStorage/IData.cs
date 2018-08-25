using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace Hotel.Core.DataStorage
{
    public interface IData
    {
        IList<IClient> Clients { get; }

        IList<IHotel> Hotels { get; }

        IList<IAccomodationProperty> Rooms { get; }

        IList<IExtra> Extras { get; }

    }
}
