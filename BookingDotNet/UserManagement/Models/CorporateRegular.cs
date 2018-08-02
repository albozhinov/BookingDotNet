using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models
{
    public class CorporateRegular : Corporate
    {
        public CorporateRegular(string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
            : base(name, numberOfEmployees, registeredOn, numberOfEmployees, telephoneNumber, email)
        {
            
        }
    }
}
