using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using UserManagement.ReservationLogic;

namespace UserManagement.Contracts
{
    public interface IClient
    {
        DateTime RegisteredOn { get; }
        int NumberOfVisits { get; }
        string TelephoneNumber { get; }
        string Email { get; }
        List<IReservation> Reservations { get; }
        void ReserveRoom(IHotel hotel, int numberOfPeople, string extras, DateTime date);
        
    }
}
