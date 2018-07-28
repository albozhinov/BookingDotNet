using HotelManagement.Common;
using System.Collections.Generic;

namespace HotelManagement.Contracts
{
    public interface IDeluxeRoom : IRoom
    {
        List<DeluxeExtras> ListOfDeluxeExtras { get; }
    }
}
