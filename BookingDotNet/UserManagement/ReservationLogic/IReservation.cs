using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.ReservationLogic
{
    public interface IReservation
    {
        IHotel Hotel { get; }
        IAccomodationProperty Room { get; }
        IClient Client { get; }
        DateTime Date { get; }
    }
}
