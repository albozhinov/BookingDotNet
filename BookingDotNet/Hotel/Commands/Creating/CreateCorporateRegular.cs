using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateCorporateRegular : ICommand
    {

        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateCorporateRegular(IHotelFactory factory, IEngine engine)
        {
            this.factory = factory ?? throw new ArgumentNullException();
            this.engine = engine ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
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
                // Alex will implement a method for the date parsing.
                //registeredOn = parameters[2];
                numberOfVisits = int.Parse(parameters[3]);
                telephoneNumber = parameters[4];
                email = parameters[5];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Corporate Regular client command parameters.");
            }

            var corpReg = this.factory.CreateCorporateRegular(numberOfVisits, telephoneNumber, email, name, numberOfEmployees);
            this.engine.Clients.Add(corpReg);

            return $"Corporate Regular client with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
