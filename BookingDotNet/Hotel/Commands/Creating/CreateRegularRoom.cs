using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateRegularRoom : ICommand
    {

        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateRegularRoom(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int capacity;
            int beds;
            bool forSmokers;
            string view;
            decimal basePrice;
            int onFloor;

            try
            {
                capacity = int.Parse(parameters[0]);
                beds = int.Parse(parameters[1]);
                forSmokers = bool.Parse(parameters[2]);
                view = parameters[3];
                basePrice = decimal.Parse(parameters[4]);
                onFloor = int.Parse(parameters[5]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateRegularRoom command parameters.");
            }

            var regularRoom = this.factory.CreateDeluxeRoom(capacity, beds, forSmokers, view, basePrice, onFloor);
            regularRoom.AddExtra(this.engine.Extras[0]);
            regularRoom.AddExtra(this.engine.Extras[1]);
            regularRoom.AddExtra(this.engine.Extras[2]);
            this.engine.Rooms.Add(regularRoom);
            engine.Rooms[engine.Rooms.Count - 1].RoomNumber = engine.Rooms.Count - 1;
            return $"Regular Room with ID {engine.Rooms.Count - 1} was created.";

        }
    }
}