using MVCAplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCAplication.DAO
{
    public class ContextDBClass: DbContext
    {
        public ContextDBClass() : base("Base03")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Measure> Measures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MVCAplication.Models.Sales> Sales { get; set; }

        public System.Data.Entity.DbSet<MVCAplication.Models.Customer> Customers { get; set; }
    }
}