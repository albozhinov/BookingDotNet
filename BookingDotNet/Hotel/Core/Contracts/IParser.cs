using Hotel.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string commandName);
    }
}
