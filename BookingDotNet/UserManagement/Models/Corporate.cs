using System;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    public abstract class Corporate : Client, ICorporateClient
    {
        private string name;
        private int numberOfEmployees;


        public Corporate(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees) 
            : base(numberOfEmployees,telephoneNumber,email)
                         
        {
            this.Name = name;
            this.NumberOfEmployees = numberOfEmployees;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validation.StringLengthCheck(3, 20, value, "");
                this.name = value;
            }
        }
        public int NumberOfEmployees
        {
            get
            {
                return this.numberOfEmployees;
            }
            set
            {
                Validation.CantBeZero(value, Constants.numberOfEmployees);
                this.numberOfEmployees = value;
            }
        }

    }
}
