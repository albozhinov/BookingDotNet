using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System.Collections.Generic;

namespace Hotel.Commands.Contracts
{
    public interface ICommand
    {
        IHotelFactory Factory { get; }
        IData Data { get; }
        string Execute(IList<string> parameters);
    }
}
