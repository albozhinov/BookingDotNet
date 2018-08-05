using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models
{
    public class CorporateRegular : Corporate
    {
        public CorporateRegular(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees)
            : base(numberOfEmployees, telephoneNumber, email, name, numberOfEmployees)
        {
            
        }
    }
}
