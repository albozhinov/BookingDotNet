using System;
using System.Collections.Generic;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListHotelCommand : ICommand
    {
        // Fields
        private readonly IHotelFactory facotry;
        private readonly IEngine engine;

        // Constructor
        public ListHotelCommand(IHotelFactory factory, IEngine engine)
        {
            this.facotry = factory;
            this.engine = engine;
        }

        // Method
        public string Execute(IList<string> parameters)
        {
            var hotels = this.engine.Hotels;

            if (hotels.Count == 0)
            {
                return "There are no registered hotel.";
            }

            return string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine + Environment.NewLine + Environment.NewLine, hotels);
        }
    }
}
