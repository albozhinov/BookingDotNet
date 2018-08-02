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

        public CorporateLoyal(decimal discount, string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
            :base(name, numberOfEmployees, registeredOn, numberOfEmployees, telephoneNumber, email)
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
    }
}
