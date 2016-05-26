using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CounterProject_MVC.Models
{
    public class CounterContext : DbContext
    {
        public CounterContext() : base("CounterContext")
        {
        }
        public DbSet<Counter> Counters { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}