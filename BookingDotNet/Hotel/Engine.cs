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

        // Property dependencty injection not validated for simplicity
        public IReader Reader
        {
            get;
            set;
        }

        public IWriter Writer { get ; set; }

        public IParser Parser { get; set; }

        public IList<IClient> Clients { get; private set; }

        public IList<IHotel> Hotels => throw new NotImplementedException();

        public IList<IAccomodationProperty> Rooms => throw new NotImplementedException();

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
