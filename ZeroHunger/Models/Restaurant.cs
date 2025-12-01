using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<CollectRequest> CollectRequests { get; set; }

        public Restaurant()
        {
            CollectRequests = new HashSet<CollectRequest>();
        }
    }
}