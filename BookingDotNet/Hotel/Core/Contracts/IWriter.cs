using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.Contracts
{
    interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
