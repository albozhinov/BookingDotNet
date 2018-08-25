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
    public class CreateDeluxeRoomCommand : Command, ICommand
    {

        public CreateDeluxeRoomCommand(IHotelFactory factory, IData data) : base(factory, data)
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
                throw new ArgumentException("Failed to parse CreateDeluxeRoom command parameters.");
            }

            var deluxeRoom = this.Factory.CreateDeluxeRoom(capacity, beds, forSmokers, view, basePrice, onFloor);
            deluxeRoom.AddExtra(this.Data.Extras[0]);
            deluxeRoom.AddExtra(this.Data.Extras[1]);
            deluxeRoom.AddExtra(this.Data.Extras[2]);
            deluxeRoom.AddExtra(this.Data.Extras[7]);
            this.Data.Rooms.Add(deluxeRoom);
            this.Data.Rooms[Data.Rooms.Count - 1].RoomNumber = Data.Rooms.Count - 1;
            return $"Deluxe Room with ID {this.Data.Rooms.Count - 1} was created.";
        }
    }
}
