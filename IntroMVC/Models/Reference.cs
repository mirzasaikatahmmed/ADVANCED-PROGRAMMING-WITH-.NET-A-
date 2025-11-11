using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class Reference
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Institution { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
    }
}