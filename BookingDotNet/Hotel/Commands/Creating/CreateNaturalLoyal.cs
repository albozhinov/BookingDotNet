using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hotel.Commands.Creating
{
    class CreateNaturalLoyal : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateNaturalLoyal(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            string firstName;
            string lastName;
            DateTime dateOfBirth;
            DateTime registeredOn;
            int numberOfVisits;
            string telephoneNumber;
            string email;
            decimal discount;

            try
            {
                firstName = parameters[0];
                lastName = parameters[1];
                dateOfBirth = DateTime.ParseExact(parameters[2], "d.M.yyyy", CultureInfo.InvariantCulture);
                registeredOn = DateTime.Now;
                numberOfVisits = int.Parse(parameters[4]);
                telephoneNumber = parameters[5];
                email = parameters[6];
                discount = decimal.Parse(parameters[7]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Natural Loyal client command parameters.");
            }

            var naturalLoyal = this.factory.CreateNaturalLoyal(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits,
                telephoneNumber, email, discount);
            this.engine.Clients.Add(naturalLoyal);

            return $"Natural Loyal client with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
