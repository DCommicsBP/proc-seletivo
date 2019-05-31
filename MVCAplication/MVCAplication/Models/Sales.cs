using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Sales
    {
        public int ID { get; set; }
        public bool IsPending{ get; set; }
        public int CustomerID { get; set; }
        public double TotalValue { get; set; }
        public List<int> Products { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}