using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class Project
    {
        public string Title { get; set; }
        public string Course { get; set; }
        public List<string> Description { get; set; }
        public string LiveDemo { get; set; }
        public string GitHub { get; set; }
    }
}