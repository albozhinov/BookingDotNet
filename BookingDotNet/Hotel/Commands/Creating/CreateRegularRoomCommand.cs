using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateRegularRoomCommand : Command, ICommand
    {

        public CreateRegularRoomCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
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

            var regularRoom = this.Factory.CreateDeluxeRoom(capacity, beds, forSmokers, view, basePrice, onFloor);
            regularRoom.AddExtra(this.Data.Extras[0]);
            regularRoom.AddExtra(this.Data.Extras[1]);
            regularRoom.AddExtra(this.Data.Extras[2]);
            this.Data.Rooms.Add(regularRoom);
            Data.Rooms[Data.Rooms.Count - 1].RoomNumber = Data.Rooms.Count - 1;
            return $"Regular Room with ID {Data.Rooms.Count - 1} was created.";

        }
    }
}