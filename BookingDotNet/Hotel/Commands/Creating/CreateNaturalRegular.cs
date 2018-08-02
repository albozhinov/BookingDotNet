using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Creating
{
    class CreateNaturalRegular : ICommand
    {
        private readonly IHotelFactory factory;
        private readonly IEngine engine;

        public CreateNaturalRegular(IHotelFactory factory, IEngine engine)
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

            try
            {
                firstName = parameters[0];
                lastName = parameters[1];
                // Alex will implement a method for the date parsing.

                //dateOfBirth = parameters[2];
                //registeredOn = parameters[3];
                numberOfVisits = int.Parse(parameters[4]);
                telephoneNumber = parameters[5];
                email = parameters[6];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Create Natural Regular client command parameters.");
            }

            var naturalReg = this.factory.CreateNaturalRegular(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNumber, email);
            this.engine.Clients.Add(naturalReg);

            return $"Natural Regular client with ID {engine.Rooms.Count - 1} was created.";
        }
    }
}
