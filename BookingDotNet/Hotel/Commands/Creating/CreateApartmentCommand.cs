using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using HotelManagement.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateApartmentCommand : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateApartmentCommand(IHotelFactory factory, IEngine engine)
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

            var apartment = this.factory.CreateApartment(capacity, beds, forSmokers, view, basePrice, fullyQuipped, bedrooms, bathrooms, onFloor);
            apartment.AddExtra(this.engine.Extras[0]);
            apartment.AddExtra(this.engine.Extras[1]);
            apartment.AddExtra(this.engine.Extras[2]);
            apartment.AddExtra(this.engine.Extras[7]);
            this.engine.Rooms.Add(apartment);
            this.engine.Rooms[engine.Rooms.Count - 1].RoomNumber = engine.Rooms.Count - 1;

            return $"Apartment with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
