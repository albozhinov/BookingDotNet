using Hotel.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.Contracts
{
    interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
