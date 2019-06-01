using MVCAplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplication.DAO
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MyDatabase")
        {
        }

        public DbSet<Release> Realeses { get; set; }
    }

}