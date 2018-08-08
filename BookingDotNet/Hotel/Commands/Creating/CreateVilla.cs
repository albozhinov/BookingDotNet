using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateVilla : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateVilla(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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

            var villa = this.factory.CreateVilla(numberOfFloors, bedrooms, bathrooms, capacity, beds, forSmokers, view, basePrice);
            villa.AddExtra(this.engine.Extras[0]);
            villa.AddExtra(this.engine.Extras[1]);
            villa.AddExtra(this.engine.Extras[2]);
            villa.AddExtra(this.engine.Extras[7]);
            villa.AddExtra(this.engine.Extras[19]);
            this.engine.Rooms.Add(villa);

            return $"Villa with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
