using System;
using System.Collections.Generic;
using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListHotelCommand : Command, ICommand
    {

        // Constructor
        public ListHotelCommand(IHotelFactory factory, IData engine) : base(factory, engine)
        {

        }

        // Method
        public override string Execute(IList<string> parameters)
        {
            var hotels = this.Data.Hotels;

            if (hotels.Count == 0)
            {
                return "There are no registered hotel.";
            }

            return string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine + Environment.NewLine + Environment.NewLine, hotels);
        }
    }
}
