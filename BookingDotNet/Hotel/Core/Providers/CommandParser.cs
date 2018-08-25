using Autofac;
using Hotel.Commands.Contracts;
using Hotel.Core.Contracts;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hotel.Core.Providers
{

    public class CommandParser : IParser
    {
        private readonly ILifetimeScope scope;

        public CommandParser(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public ICommand ParseCommand(string commandName)
        {
            //Added simple validation - if command is not found, the processor will recieve null and handle the unexpected behaviour
            try
            {
                return scope.ResolveNamed<ICommand>(commandName.ToLower());
            }
            catch
            {
                return null;
            }

        }
    }
}