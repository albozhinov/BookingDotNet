using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using HotelManagement.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class AddExtra
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public AddExtra(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            int id;
            string extra;

            try
            {
                id = int.Parse(parameters[0]);
                extra = parameters[1];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateApartment command parameters.");
            }

            var extra = this.factory.AddExtra(id,extra);
            this.engine.Rooms.Add(apartment);

            return $"Apartment with ID {engine.Rooms.Count - 1} was created.";
        }
}
