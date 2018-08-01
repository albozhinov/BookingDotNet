using System;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    public class NaturalLoyal : Natural, INaturalClient
    {
        // Fields
        private decimal discount;

        // Constructor
        public NaturalLoyal(string firstName, string lastName, DateTime dateOfBirth, DateTime registeredOn,
                            int numberOfVisits, string telephoneNimber, string email, decimal distcount)
            : base(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNimber, email)
        {
            this.Discount = distcount;
        }

        // Properties
        public decimal Discount
        {
            get => this.discount;
            set
            {
                Validation.NumberBorderCheck(0.05M, 0.2M, value, Constants.discount);
                this.discount = value;
            }
        }
    }
}
