namespace HotelManagement.Contracts
{
    public interface IApartment : ICompleteEstate
    {
        bool FullyQuipped { get; }
    }
}
