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
                            int numberOfVisits, string telephoneNumber, string email, decimal discount)
            : base(firstName, lastName, dateOfBirth, registeredOn, numberOfVisits, telephoneNumber, email)
        {
            this.Discount = discount;
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
