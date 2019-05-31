using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Sales
    {
        [Key()]
        public int ID { get; set; }

        public bool IsPending{ get; set; }
        
        public double TotalValue { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Sales_Products")]
        public virtual ICollection<Product> Products { get; set; }
    }
}