namespace HotelManagement.Contracts
{
    public interface IApartment : ICompleteEstate, IRoom
    {
        bool FullyQuipped { get; }
    }
}
