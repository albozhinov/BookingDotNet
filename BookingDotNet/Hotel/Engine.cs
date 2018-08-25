using System;
using Hotel.Core.Contracts;

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

        }

        //Autofac handles this
        public IReader Reader { get; private set; }        

        public IWriter Writer { get ; private set; }

        public IProcessor Processor { get; private set; }

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
                   var executionResult =  this.Processor.ProcessCommand(commandAsString);
                   this.Writer.WriteLine(executionResult);

                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }                
            }
        }

    }
}
