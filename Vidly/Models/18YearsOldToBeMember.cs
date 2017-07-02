using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class YearsOld18ToBeMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == (byte) MembershipType.Known || customer.MembershipTypeId == (byte) MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate == null)
                return new ValidationResult("Date of birth is required");
            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("The customer shoul be 18 years old");

        }
    }
}