using System;
using System.Collections.Generic;

namespace HotelManagement.Contracts
{
    public interface IHotel
    {
        string Name { get; }
        int Floors { get; }
        List<IAccomodationProperty> Rooms { get; }
        string checkAvailability(int numberOfPeople, string extras, DateTime date);
    }
}