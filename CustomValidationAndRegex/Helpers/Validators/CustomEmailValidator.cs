using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomValidationAndRegex.Helpers.Validators
{
    public class CustomEmailValidator:ValidationAttribute
    {
        private static readonly Regex Pattern = new Regex(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var email = value as string;
            if (string.IsNullOrWhiteSpace(email))
            {
                return ValidationResult.Success;
            }

            if (!Pattern.IsMatch(email))
            {
                var msg = string.IsNullOrWhiteSpace(ErrorMessage) ? $"{validationContext.DisplayName} must be like 22-47472-2@student.aiub.edu." : ErrorMessage;
                return new ValidationResult(msg);
            }

            var idProperty = validationContext.ObjectType.GetProperty("Id");
            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(validationContext.ObjectInstance, null) as string;

                if (!string.IsNullOrEmpty(idValue))
                {
                    var emailPrefix = email.Split('@')[0];

                    if (!emailPrefix.Equals(idValue, StringComparison.OrdinalIgnoreCase))
                    {
                        return new ValidationResult("Email must exactly match the student ID (e.g., xx-xxxx-x@student.aiub.edu).");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}