using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;
using Utility;

namespace UserManagement.Models
{
    public class CorporateLoyal: Corporate, ICorporateClient
    {
        decimal discount;

        public CorporateLoyal(int numberOfVisits, string telephoneNumber, string email, string name, int numberOfEmployees, decimal discount)
            : base(numberOfEmployees, telephoneNumber, email, name, numberOfEmployees)
        {
            this.Discount = discount;
        }

        public decimal Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                Validation.NumberBorderCheck(0.05m, 0.2m, value, "");
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
