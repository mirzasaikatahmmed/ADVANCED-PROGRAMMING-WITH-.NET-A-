using CustomValidationAndRegex.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidationAndRegex.Models
{
    public class Auth
    {
        [Required]
        [RegularExpression(@"^[A-Za-z .-]+$", ErrorMessage = "Name may only contain letters, spaces, dots (.), and dashes (-).")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain spaces.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be in the format xx-xxxxx-x (last digit 1–3).")]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomDobValidator(18, ErrorMessage = "You must be at least 18 years old.")]
        public DateTime? Dob { get; set; }

        [Required]
        [CustomEmailValidator(ErrorMessage = "Email must be like xx-xxxxx-x@student.aiub.edu.")]
        public string Email { get; set; }
    }
}