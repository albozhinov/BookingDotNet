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
    public class CreateCorporateLoyalCommand : Command, ICommand
    {

        public CreateCorporateLoyalCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            decimal discount;
            string name;
            int numberOfEmployees;
            DateTime registeredOn;
            int numberOfVisits;
            string telephoneNumber;
            string email;

            try
            {
                name = parameters[1];
                numberOfEmployees = int.Parse(parameters[2]);
                discount = decimal.Parse(parameters[0]);
                registeredOn = DateTime.Now.Date;
                numberOfVisits = int.Parse(parameters[3]);
                telephoneNumber = parameters[4];
                email = parameters[5];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Corporate Loyal client command parameters.");
            }

            var corpLoyal = this.Factory.CreateCorporateLoyal(numberOfVisits, telephoneNumber, email, name, numberOfEmployees, discount);
            this.Data.Clients.Add(corpLoyal);

            return $"Corporate Loyal client with ID {Data.Clients.Count - 1} was created.";

        }
    }
}
