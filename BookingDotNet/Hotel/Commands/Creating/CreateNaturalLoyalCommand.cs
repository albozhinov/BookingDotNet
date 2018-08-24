using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hotel.Commands.Creating
{
    class CreateNaturalLoyalCommand : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateNaturalLoyalCommand(IHotelFactory factory, IEngine engine)
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
                dateOfBirth = DateTime.ParseExact(parameters[2], "d/M/yyyy", CultureInfo.InvariantCulture);
                registeredOn = DateTime.Now.Date;
                numberOfVisits = int.Parse(parameters[3]);
                telephoneNumber = parameters[4];
                email = parameters[5];
                discount = decimal.Parse(parameters[6]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Natural Loyal client command parameters.");
            }

            var naturalLoyal = this.factory.CreateNaturalLoyal(numberOfVisits, telephoneNumber, email, firstName, lastName, dateOfBirth, discount);
            this.engine.Clients.Add(naturalLoyal);

            return $"Natural Loyal client with ID {engine.Clients.Count - 1} was created.";
        }
    }
}
