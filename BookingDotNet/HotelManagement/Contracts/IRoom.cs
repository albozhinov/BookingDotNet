namespace HotelManagement.Contracts
{
    public interface IRoom : IAccomodationProperty
    {
        int OnFloor { get; }
    }
}