using System.Collections.Generic;

namespace HotelManagement.Contracts
{
    public interface IHotel
    {
        List<IRoom> Rooms { get; }
    }
}