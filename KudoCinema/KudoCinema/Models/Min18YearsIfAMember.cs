using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KudoCinema.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == (int)MembershipType.MemberShipType_TypeCode.PaysAsYouGo)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.Birthday == null)
                {
                    return new ValidationResult("Birthday is required");
                }

                var age = DateTime.Now.Year - customer.Birthday.Value.Year;
                return (age >= 18) ? ValidationResult.Success
                                    : new ValidationResult("Customer has to at least 18 years old if a member!");
            }           
        }
    }
}