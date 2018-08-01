using System;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    class Corporate : ICorporateClient
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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validation.StringLengthCheck(3, 20, value,"");
                this.name = value;
            }
        }
        public int NumberOfEmployees {
            get
            {
                return this.numberOfEmployees;
            }
            set
            {
                Validation.CantBeZero(value, "");
                this.numberOfEmployees = value;
            }
        }
        public DateTime RegisteredOn { get; set; }
        public int NumberOfVisits {
        get
            {
                return this.numberOfVisits;
            }
            set
            {
                Validation.CantBeZero(value, "");
                this.numberOfVisits = value;
            }
        }
        public string TelephoneNumber
        {
            get
            {
                return this.telephoneNumber;
            }
            set
            {
                Validation.StringLengthCheck(8, 12, value, Constants.telNo);
                this.telephoneNumber = value;
            }
        }
        public string Email { get; set; }
    }
}
