using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class Education
    {
        public string Degree { get; set; }
        public string InstitutionName { get; set; }
        public string Group { get; set; }
        public int PassingYear { get; set; }
        public double Result { get; set; }
        public string Board { get; set; }
    }
}