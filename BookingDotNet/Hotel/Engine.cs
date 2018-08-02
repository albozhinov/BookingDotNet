using System;
using System.Collections.Generic;
using Hotel.Core.Contracts;
using Hotel.Core.Providers;
using HotelManagement.Contracts;
using UserManagement.Contracts;

namespace Hotel
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;

        private const string ExitCommand = "Exit";
        private const string CannotBeNullMessage = "cannot be null.";

        // private because of Singleton design pattern
        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();

            this.Rooms = new List<IAccomodationProperty>();
            this.Hotels = new List<IHotel>();
            this.Clients = new List<IClient>();
        }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }
                return instanceHolder;
            }
        }

        // Property dependencty injection not validated for simplicity
        public IReader Reader { get; set; }        

        public IWriter Writer { get ; set; }

        public IParser Parser { get; set; }

        public IList<IClient> Clients { get; private set; }

        public IList<IHotel> Hotels { get; private set; }

        public IList<IAccomodationProperty> Rooms { get; private set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == ExitCommand.ToLower())
                    {
                        break;
                    }
                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }                
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString)
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}
