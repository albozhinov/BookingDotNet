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
            return scope.ResolveNamed<ICommand>(commandName.ToLower());
        }
    }
}