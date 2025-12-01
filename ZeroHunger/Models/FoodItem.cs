using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        public int CollectRequestId { get; set; }

        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Notes { get; set; }

        public virtual CollectRequest CollectRequest { get; set; }
    }
}