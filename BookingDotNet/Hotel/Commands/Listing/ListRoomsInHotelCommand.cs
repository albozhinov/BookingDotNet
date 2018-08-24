using System;
using System.Collections.Generic;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListRoomsInHotelCommand : ICommand
    {
        // Fields
        private readonly IHotelFactory facotry;
        private readonly IEngine engine;

        // Constructor
        public ListRoomsInHotelCommand(IHotelFactory factory, IEngine engine)
        {
            this.facotry = factory;
            this.engine = engine;
        }

        // Method
        public string Execute(IList<string> parameters)
        {
            int hotelId = int.Parse(parameters[0]);

            if (this.engine.Hotels[hotelId].Rooms.Count == 0)
            {
                return "There are no registered rooms in this hotel.";
            }

            return $"Rooms in hotel: {this.engine.Hotels[hotelId].Name}" +
                $"\n\r \n\r {string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine, this.engine.Hotels[hotelId].Rooms)}";
        }
    }
}
