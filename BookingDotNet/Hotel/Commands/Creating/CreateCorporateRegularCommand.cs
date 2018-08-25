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
    class CreateCorporateRegularCommand : Command, ICommand
    {

        public CreateCorporateRegularCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            string name;
            int numberOfEmployees;
            DateTime registeredOn;
            int numberOfVisits;
            string telephoneNumber;
            string email;

            try
            {
                name = parameters[0];
                numberOfEmployees = int.Parse(parameters[1]);                
                registeredOn = DateTime.Now.Date;
                numberOfVisits = int.Parse(parameters[2]);
                telephoneNumber = parameters[3];
                email = parameters[4];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Corporate Regular client command parameters.");
            }

            var corpReg = this.Factory.CreateCorporateRegular(numberOfVisits, telephoneNumber, email, name, numberOfEmployees);
            this.Data.Clients.Add(corpReg);

            return $"Corporate Regular client with ID {this.Data.Clients.Count - 1} was created.";
        }
    }
}
