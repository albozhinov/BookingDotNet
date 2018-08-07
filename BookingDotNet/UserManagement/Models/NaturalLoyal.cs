using System;
using System.Text;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    public class NaturalLoyal : Natural, INaturalClient
    {
        // Fields
        private decimal discount;

        // Constructor
        public NaturalLoyal(int numberOfVisit, string telephoneNumber, string email, string firstName, string lastName, DateTime dateOfBirth, decimal discount) 
            : base(numberOfVisit, telephoneNumber, email, firstName, lastName, dateOfBirth)
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
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"===== Discount: {this.Discount*100}%");
            return sb.ToString();
        }
    }
}
