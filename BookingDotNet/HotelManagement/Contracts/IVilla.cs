namespace HotelManagement.Contracts
{
    public interface IVilla : ICompleteEstate
    {
        int NumberOfFloors { get; }
    }
}