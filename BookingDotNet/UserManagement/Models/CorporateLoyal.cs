using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace UserManagement.Models
{
    class CorporateLoyal: Corporate, ICorporateClient
    {
        decimal discount;

        public CorporateLoyal(decimal discount, string name, int numberOfEmployees, DateTime registeredOn, int numberOfVisits,
             string telephoneNumber, string email)
            :base(name, numberOfEmployees, registeredOn, numberOfEmployees, telephoneNumber, email)
        {
            this.Discount = discount;
        }

        public decimal Discount { get; set; }
    }
}
