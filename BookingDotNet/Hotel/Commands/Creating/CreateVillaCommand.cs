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
    public class CreateVillaCommand : Command, ICommand
    {

        public CreateVillaCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int numberOfFloors;
            int bedrooms;
            int bathrooms;
            int capacity;
            int beds;
            bool forSmokers;
            string view;
            decimal basePrice;

            try
            {
                numberOfFloors = int.Parse(parameters[0]);
                bedrooms = int.Parse(parameters[1]);
                bathrooms = int.Parse(parameters[2]);
                capacity = int.Parse(parameters[3]);
                beds = int.Parse(parameters[4]);
                forSmokers = bool.Parse(parameters[5]);
                view = parameters[6];
                basePrice = decimal.Parse(parameters[7]);

            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateVilla command parameters.");
            }

            var villa = this.Factory.CreateVilla(numberOfFloors, bedrooms, bathrooms, capacity, beds, forSmokers, view, basePrice);
            villa.AddExtra(this.Data.Extras[0]);
            villa.AddExtra(this.Data.Extras[1]);
            villa.AddExtra(this.Data.Extras[2]);
            villa.AddExtra(this.Data.Extras[7]);
            villa.AddExtra(this.Data.Extras[19]);
            this.Data.Rooms.Add(villa);
            Data.Rooms[Data.Rooms.Count - 1].RoomNumber = Data.Rooms.Count - 1;
            return $"Villa with ID {Data.Rooms.Count - 1} was created.";
        }
    }
}
