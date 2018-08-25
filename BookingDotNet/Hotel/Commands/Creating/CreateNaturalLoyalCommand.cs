using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hotel.Commands.Creating
{
    class CreateNaturalLoyalCommand : Command, ICommand
    {

        public CreateNaturalLoyalCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
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

            var naturalLoyal = this.Factory.CreateNaturalLoyal(numberOfVisits, telephoneNumber, email, firstName, lastName, dateOfBirth, discount);
            this.Data.Clients.Add(naturalLoyal);

            return $"Natural Loyal client with ID {this.Data.Clients.Count - 1} was created.";
        }
    }
}
