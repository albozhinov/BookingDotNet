using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hotel.Commands.Creating
{
    public class CreateNaturalRegularCommand : Command, ICommand
    {

        public CreateNaturalRegularCommand(IHotelFactory factory, IData data) : base(factory, data)
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

            try
            {
                firstName = parameters[0];
                lastName = parameters[1];
                dateOfBirth = DateTime.ParseExact(parameters[2], "d/M/yyyy", CultureInfo.InvariantCulture);
                registeredOn = DateTime.Now.Date;
                numberOfVisits = int.Parse(parameters[3]);
                telephoneNumber = parameters[4];
                email = parameters[5];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Natural Regular client command parameters.");
            }

            var naturalReg = this.Factory.CreateNaturalRegular(numberOfVisits, telephoneNumber, email,  firstName, lastName, dateOfBirth);
            this.Data.Clients.Add(naturalReg);

            return $"Natural Regular client with ID {Data.Clients.Count - 1} was created.";
        }
    }
}
