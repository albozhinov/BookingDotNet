using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Listing
{
    class ListRoomsInHotel : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public ListRoomsInHotel(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = this.engine.Rooms;

            if (tickets.Count == 0)
            {
                return "There are no registered rooms.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
