using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    public class NaturalRegular : Natural, INaturalClient
    {
        public NaturalRegular(int numberOfVisit, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth)
            : base(numberOfVisit, telephoneNumber, email, firstName, lastName, dateOfBirth)
        {

        }
    }
}
