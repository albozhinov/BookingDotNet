using System;
using System.Collections.Generic;
using Hotel.Commands.Common;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;

namespace Hotel.Commands.Listing
{
    public class ListClientsCommand : Command, ICommand
    {

        // Constructor
        public ListClientsCommand(IHotelFactory factory, IData data) : base(factory, data)
        {

        }

        // Method
        public override string Execute(IList<string> parameters)
        {
            var clients = this.Data.Clients;

            if (clients.Count == 0)
            {
                return "There are no registered client.";
            }

            return string.Join(Environment.NewLine + new string('*', 20) + Environment.NewLine, clients);
        }
    }
}
