using Hotel.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
