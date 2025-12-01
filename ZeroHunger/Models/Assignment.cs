using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public int CollectRequestId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime AssignedAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public DateTime? CollectedAt { get; set; }
        public string Note { get; set; }

        public virtual CollectRequest CollectRequest { get; set; }
        public virtual Employee Employee { get; set; }
    }
}