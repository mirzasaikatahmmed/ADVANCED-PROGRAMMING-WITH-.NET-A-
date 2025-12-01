using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }

        public Employee()
        {
            Assignments = new HashSet<Assignment>();
            Distributions = new HashSet<Distribution>();
        }
    }
}