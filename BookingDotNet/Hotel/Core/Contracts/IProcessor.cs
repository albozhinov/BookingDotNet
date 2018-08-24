using Hotel.Commands.Contracts;


namespace Hotel.Core.Contracts
{
    public interface IProcessor
    {
        string ProcessCommand(string line);
    }
}
