using System;

namespace UserManagement.Contracts
{
    public interface INaturalClient : IClient
    {
        string firstName { get; }
        string lastName { get; }
        DateTime dateOfBirth { get; }
    }
}