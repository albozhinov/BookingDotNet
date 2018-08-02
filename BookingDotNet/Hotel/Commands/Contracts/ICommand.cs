using System.Collections.Generic;

namespace Hotel.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
