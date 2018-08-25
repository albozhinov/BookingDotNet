using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateApartmentCommand : Command, ICommand
    {

        public CreateApartmentCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int capacity;
            int beds;
            bool forSmokers;
            string view;
            decimal basePrice;
            bool fullyQuipped;
            int bedrooms;
            int bathrooms;
            int onFloor;

            try
            {
                capacity = int.Parse(parameters[0]);
                beds = int.Parse(parameters[1]);
                forSmokers = bool.Parse(parameters[2]);
                view = parameters[3];
                basePrice = decimal.Parse(parameters[4]);
                fullyQuipped = bool.Parse(parameters[5]);
                bedrooms = int.Parse(parameters[6]);
                bathrooms = int.Parse(parameters[7]);
                onFloor = int.Parse(parameters[8]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateApartment command parameters.");
            }

            var apartment = this.Factory.CreateApartment(capacity, beds, forSmokers, view, basePrice, fullyQuipped, bedrooms, bathrooms, onFloor);
            apartment.AddExtra(this.Data.Extras[0]);
            apartment.AddExtra(this.Data.Extras[1]);
            apartment.AddExtra(this.Data.Extras[2]);
            apartment.AddExtra(this.Data.Extras[7]);
            this.Data.Rooms.Add(apartment);
            this.Data.Rooms[Data.Rooms.Count - 1].RoomNumber = Data.Rooms.Count - 1;

            return $"Apartment with ID {Data.Rooms.Count - 1} was created.";
        }
    }
}
