using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidationAndRegex.Helpers.Validators
{
    public class CustomDobValidator:ValidationAttribute
    {
        private readonly int _minimumAge;

        public CustomDobValidator(int minimumAge = 18)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is DateTime dob))
            {
                return new ValidationResult($"Invalid {validationContext.DisplayName}.");
            }

            var today = DateTime.Today;
            if (dob.Date > today)
            {
                return new ValidationResult($"{validationContext.DisplayName} cannot be in the future.");
            }

            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age >= _minimumAge)
            {
                return ValidationResult.Success;
            }

            var msg = string.IsNullOrWhiteSpace(ErrorMessage) ? $"You must be at least {_minimumAge} years old." : ErrorMessage;

            return new ValidationResult(msg);
        }
    }
}