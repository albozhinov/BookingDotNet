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

        private const string ExitCommand = "Exit";
        private const string CannotBeNullMessage = "cannot be null.";

        // private because of Singleton design pattern
        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Processor = processor;

            //Potentially make a data class to hold these!!!
            this.Rooms = new List<IAccomodationProperty>();
            this.Hotels = new List<IHotel>();
            this.Clients = new List<IClient>();
            this.Extras = new List<IExtra>();
        }


        // Property dependency injection not validated for simplicity - private setter - autofac handles this
        public IReader Reader { get; private set; }        

        public IWriter Writer { get ; private set; }

        public IProcessor Processor { get; private set; }

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
                   var executionResult =  this.Processor.ProcessCommand(commandAsString);
                   this.Writer.WriteLine(executionResult);

                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }                
            }
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
