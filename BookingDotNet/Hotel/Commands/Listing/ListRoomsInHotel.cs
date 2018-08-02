using System;
using System.Collections.Generic;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListRoomsInHotel : ICommand
    {
        // Fields
        private readonly IHotelFactory facotry;
        private readonly IEngine engine;

        // Constructor
        public ListRoomsInHotel(IHotelFactory factory, IEngine engine)
        {
            this.facotry = factory;
            this.engine = engine;
        }

        // Method
        public string Execute(IList<string> parameters)
        {
            var rooms = this.engine.Rooms;

            if (rooms.Count == 0)
            {
                return "There are no registered room.";
            }

            return string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine, rooms);
        }
    }
}
