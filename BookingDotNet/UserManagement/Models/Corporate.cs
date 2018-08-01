using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    public abstract class Corporate : ICorporateClient
    {
        private string name;
        private int numberOfEmployees;
        private DateTime registeredOn;
        private int numberOfVisits;
        private string telephoneNumber;
        private string email;

        public Corporate(string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
        {
            this.Name = name;
            this.NumberOfEmployees = numberOfEmployees;
            this.RegisteredOn = registeredOn;
            this.NumberOfVisits = numberOfVisits;
            this.TelephoneNumber = telephoneNumber;
            this.Email = email;
         }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime RegisteredOn { get; set; }
        public int NumberOfVisits { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

    }
}
