using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace Hotel.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        IList<IClient> Clients { get; }

        IList<IHotel> Hotels { get; }

        IList<IAccomodationProperty> Rooms { get; }
    }
}
