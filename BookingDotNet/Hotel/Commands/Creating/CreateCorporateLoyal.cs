using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateCorporateLoyal : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateCorporateLoyal(IHotelFactory factory, IEngine engine)
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
                discount = decimal.Parse(parameters[0]);
                name = parameters[1];
                numberOfEmployees = int.Parse(parameters[2]);
                // Alex will implement a method for the date parsing.
                //registeredOn = parameters[3];
                numberOfVisits = int.Parse(parameters[4]);
                telephoneNumber = parameters[5];
                email = parameters[6];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Corporate Loyal client command parameters.");
            }

            var corpLoyal = this.factory.CreateCorporateLoyal(discount, name, numberOfEmployees, registeredOn,
                numberOfVisits, telephoneNumber, email);
            this.engine.Clients.Add(corpLoyal);

            return $"Corporate Loyal client with ID {engine.Rooms.Count - 1} was created.";

        }
    }
}
