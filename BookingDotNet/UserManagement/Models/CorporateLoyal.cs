using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    class CorporateLoyal: ICorporateClient
    {
        decimal discount;

        public CorporateLoyal(string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits, 
            string telephoneNumber, string email)
        {
            this.Name = name;
            this.NumberOfEmployees = numberOfEmployees;
            this.
        }

        public string Name { get; set; }

        public int NumberOfEmployees{ get; set; }

        public DateTime RegisteredOn{ get; set; }

        public int NumberOfVisits{ get; set; }

        public string TelephoneNumber{ get; set; }

        public string Email{ get; set; }
    }
}
