using System;
using System.Collections.Generic;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    class ListClientsCommand : ICommand
    {
        // Fields
        private readonly IHotelFactory facotry;
        private readonly IEngine engine;

        // Constructor
        public ListClientsCommand(IHotelFactory factory, IEngine engine)
        {
            this.facotry = factory;
            this.engine = engine;
        }

        // Method
        public string Execute(IList<string> parameters)
        {
            var clients = this.engine.Clients;

            if (clients.Count == 0)
            {
                return "There are no registered client.";
            }

            return string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine, clients);
        }
    }
}
