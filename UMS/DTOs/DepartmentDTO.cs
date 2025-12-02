using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMS.DTOs
{
    public class DepartmentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}