using System;

namespace UserManagement.Contracts
{
    public interface IClient
    {
        DateTime registeredOn { get; }
        int numberOfVisits { get; }
        string telephoneNumber { get; }
        string email { get; }
    }
}
