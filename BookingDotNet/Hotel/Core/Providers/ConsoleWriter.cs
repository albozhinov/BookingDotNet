using Hotel.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.Providers
{
    class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
