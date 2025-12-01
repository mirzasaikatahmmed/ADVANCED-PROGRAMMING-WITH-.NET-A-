using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Distribution
    {
        public int Id { get; set; }

        public int CollectRequestId { get; set; }
        public int? EmployeeId { get; set; }

        public DateTime DistributedAt { get; set; }
        public string Quantity { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }

        public virtual CollectRequest CollectRequest { get; set; }
        public virtual Employee Employee { get; set; }
    }
}