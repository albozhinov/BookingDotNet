namespace UserManagement.Contracts
{
    public interface ICorporateClient : IClient
    {
        string Name { get; }
        int NumberOfEmployees { get; }
    }
}