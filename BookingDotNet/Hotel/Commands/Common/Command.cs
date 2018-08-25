using Hotel.Commands.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Commands.Common
{
    public abstract class Command : ICommand
    {
        public Command(IHotelFactory factory, IData data)
        {
            this.Factory = factory;
            this.Data = data;
        }

        public IHotelFactory Factory { get; private set; }

        public IData Data { get; private set; }

        public abstract string Execute(IList<string> parameters);

    }
}
