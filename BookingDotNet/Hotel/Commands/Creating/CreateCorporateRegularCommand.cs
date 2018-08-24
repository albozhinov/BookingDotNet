using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateCorporateRegularCommand : ICommand
    {

        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateCorporateRegularCommand(IHotelFactory factory, IEngine engine)
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
                registeredOn = DateTime.Now.Date;
                numberOfVisits = int.Parse(parameters[2]);
                telephoneNumber = parameters[3];
                email = parameters[4];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Corporate Regular client command parameters.");
            }

            var corpReg = this.factory.CreateCorporateRegular(numberOfVisits, telephoneNumber, email, name, numberOfEmployees);
            this.engine.Clients.Add(corpReg);

            return $"Corporate Regular client with ID {engine.Clients.Count - 1} was created.";
        }
    }
}
