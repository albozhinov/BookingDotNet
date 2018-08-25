using System;
using System.Collections.Generic;
using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListRoomsInHotelCommand : Command, ICommand
    {

        // Constructor
        public ListRoomsInHotelCommand(IHotelFactory factory, IData engine) : base(factory, engine)
        {

        }

        // Method
        public override string Execute(IList<string> parameters)
        {
            int hotelId = int.Parse(parameters[0]);

            if (this.Data.Hotels[hotelId].Rooms.Count == 0)
            {
                return "There are no registered rooms in this hotel.";
            }

            return $"Rooms in hotel: {this.Data.Hotels[hotelId].Name}" +
                $"\n\r \n\r {string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine, this.Data.Hotels[hotelId].Rooms)}";
        }
    }
}
