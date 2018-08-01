using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;
using Utility;

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
        private string telephoneNumber;
        private string email;

        // Constructor
        public Natural(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                        int numberOfVisits, string telephoneNimber, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.RegisteredOn = registeredOn;
            this.NumberOfVisits = numberOfVisits;
            this.TelephoneNumber = telephoneNimber;
            this.Email = email;
        }

        // Properties
        public string FirstName
        {
            get => this.firstName;
            set
            {
                Validation.StringLengthCheck(2, 15, value, Constants.userName);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                Validation.StringLengthCheck(2, 15, value, Constants.userName);
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                this.dateOfBirth = value;
            }
        }        
        
        public DateTime RegisteredOn
        {
            get => this.registeredOn;
            set
            {
                this.registeredOn = value;
            }
        }

        public int NumberOfVisits
        {
            get => this.numberOfVisits;
            set
            {
                Validation.CantBeZero(value, Constants.numberOfVisits);
                this.numberOfVisits = value;
            }
        }

        public string TelephoneNumber
        {
            get => this.telephoneNumber;
            set
            {
                Validation.StringLengthCheck(8, 12, value, Constants.telNo);
                this.telephoneNumber = value;
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                Validation.StringLengthCheck(8, 20, value, Constants.email);
                this.email = value;
            }
        }
    }
}
