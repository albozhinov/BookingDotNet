using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateHotel : ICommand
    {

        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateHotel(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            string name;
            int floors;

            try
            {
                name = parameters[0];
                floors = int.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateHotel command parameters.");
            }

            var hotel = this.factory.CreateHotel(name, floors);
            this.engine.Hotels.Add(hotel);

            return $"Hotel with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
