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
        public Natural()
        {

        }

        // Properties
        public string FirstName
        {
            get => this.firstName;
            set
            {
                Validation.StringLengthCheck(2, 15, value, errMessage);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                Validation.StringLengthCheck(2, 15, value, errMessage);
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {

            }
        }        
        
        public DateTime RegisteredOn
        {
            get => this.registeredOn;
            set
            {

            }
        }

        public int NumberOfVisits
        {
            get => this.numberOfVisits;
            set
            {

            }
        }

        public string TelephoneNumber
        {
            get => this.telephoneNumber;
            set
            {

            }
        }

        public string Email
        {
            get => this.email;
            set
            {

            }
        }
    }
}
