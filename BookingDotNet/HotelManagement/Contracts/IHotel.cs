using System;
using System.Collections.Generic;

namespace HotelManagement.Contracts
{
    public interface IHotel
    {
        string Name { get; }
        int Floors { get; }
        List<IAccomodationProperty> Rooms { get; }
        IAccomodationProperty checkAvailability(int numberOfPeople, string extras, DateTime date);
        void AddRoom(IAccomodationProperty room);
    }
}