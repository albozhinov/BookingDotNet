using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    public abstract class Natural : INaturalClient
    {
        // Fields
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private DateTime registeredOn;
        private int numberOfVisits;
        private string email;


        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();

        public DateTime dateOfBirth => throw new NotImplementedException();

        public DateTime registeredOn => throw new NotImplementedException();

        public int numberOfVisits => throw new NotImplementedException();

        public string telephoneNumber => throw new NotImplementedException();

        public string email => throw new NotImplementedException();
    }
}
