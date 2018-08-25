using HotelManagement.Common;
using HotelManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace Hotel.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; }

        IWriter Writer { get; }

        IProcessor Processor { get; }

    }
}
