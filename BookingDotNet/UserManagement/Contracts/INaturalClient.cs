using System;

namespace UserManagement.Contracts
{
    public interface INaturalClient : IClient
    {
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
    }
}