using Hotel.Core.Contracts;
using System;
using System.Linq;


namespace Hotel.Core.Providers
{
    public class CommandProcessor : IProcessor
    {
        private readonly IParser parser;

        public CommandProcessor(IParser parser)
        {
            this.parser = parser;
        }

        public string ProcessCommand(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            var arguments = line.Split(" ").Select(x => x.ToLower()).ToList();
            var commandName = arguments[0];
            var commandArguments = arguments.Skip(1).ToList();
            var command = parser.ParseCommand(commandName);
            if(command == null)
            {
                throw new ArgumentNullException("Command not found");
            }
            else
            {
                return command.Execute(commandArguments);
            }

        }
    }
}
