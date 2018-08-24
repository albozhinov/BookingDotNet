using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateCorporateLoyalCommand : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateCorporateLoyalCommand(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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

            var corpLoyal = this.factory.CreateCorporateLoyal(numberOfVisits, telephoneNumber, email, name, numberOfEmployees, discount);
            this.engine.Clients.Add(corpLoyal);

            return $"Corporate Loyal client with ID {engine.Clients.Count - 1} was created.";

        }
    }
}
