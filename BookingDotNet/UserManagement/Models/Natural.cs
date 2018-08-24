using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    public abstract class Natural : Client, INaturalClient
    {
        // Fields
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;


        // Constructor
        public Natural(int numberOfVisit, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth) : base(numberOfVisit,telephoneNumber,email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;

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
                var yearsOld = Math.Floor((DateTime.Now - value).TotalDays / 365);
                Validation.NumberBorderCheck(18d, 100d, yearsOld, Constants.clientAge);
                this.dateOfBirth = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            //sb.AppendLine($"===== Specific information for user");
            sb.AppendLine($"\r\n===== Name: {this.FirstName} {this.LastName}");
            sb.AppendLine($"===== Date of birth: {this.dateOfBirth.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }

    }
}
