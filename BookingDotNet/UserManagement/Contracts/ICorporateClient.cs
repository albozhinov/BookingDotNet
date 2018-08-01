namespace UserManagement.Contracts
{
    public interface ICorporateClient : IClient
    {
        string name { get; }
        string numberOfEmployees { get; }
    }
}