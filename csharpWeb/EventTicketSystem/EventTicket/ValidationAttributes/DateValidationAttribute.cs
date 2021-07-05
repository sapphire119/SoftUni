using EventTicket.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EventTicket.ValidationAttributes
{
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            throw new ArgumentException();
            var currentDate = value as DateTime?;
            if (currentDate == null)
            {
                return new ValidationResult(
                    this.ErrorMessage != null ? string.Format(this.ErrorMessage, validationContext.DisplayName) : this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
