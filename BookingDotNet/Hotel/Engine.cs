using System;
using System.Collections.Generic;
using Hotel.Core.Contracts;
using Hotel.Core.Providers;
using HotelManagement.Common;
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

            this.Extras = new List<IExtra>();
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

        public IList<IExtra> Extras { get; private set; }

        public void Start()
        {
            InitializeExtras();
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
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
        private void InitializeExtras()
        {
            foreach(AvailableExtras extra in Enum.GetValues(typeof(AvailableExtras)))
            {
                int tier = 1;
                int price = 0;
                if(((int)extra > 5 && (int)extra < 12))
                {
                    tier = 2;
                    price = 2;
                }
                else if (((int)extra > 11 && (int)extra < 18))
                {
                    tier = 3;
                    price = 3;
                }
                else if ((int)extra > 17)
                {
                    tier = 4;
                    price = 4;
                }
                this.Extras.Add(new Extra(tier, extra, price));
            }
        }
    }
}
