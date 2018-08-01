using System;

namespace UserManagement.Contracts
{
    public interface IClient
    {
        DateTime RegisteredOn { get; }
        int NumberOfVisits { get; }
        string TelephoneNumber { get; }
        string Email { get; }
    }
}
