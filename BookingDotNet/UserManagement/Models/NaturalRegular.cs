using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    public class NaturalRegular : Natural, INaturalClient
    {
        public NaturalRegular(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                              int numberOfVisits, string telephoneNumber, string email)
            : base(firstName , lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNumber, email)
        {

        }
    }
}
