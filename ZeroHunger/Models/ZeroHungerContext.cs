using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class ZeroHungerContext : DbContext
    {
        public ZeroHungerContext() : base("name=ZeroHungerContext")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
