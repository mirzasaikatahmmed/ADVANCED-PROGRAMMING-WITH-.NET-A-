using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class CollectRequest
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? MaxPreserveUntil { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
        public string EstimatedQuantity { get; set; }
        public string PickupAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }

        public CollectRequest()
        {
            Assignments = new HashSet<Assignment>();
            Distributions = new HashSet<Distribution>();
            FoodItems = new HashSet<FoodItem>();
        }
    }
}