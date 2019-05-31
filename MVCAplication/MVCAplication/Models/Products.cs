using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Product
    {
        [Key()]
        public int ID { get; set; }
        public string  Name{ get; set; }
        public string  Description { get; set; }
        public float Value { get; set; }
        public double quantity { get; set; }

        [ForeignKey("Measure")]
        public int MeasureID { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeID { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual ProductType ProductType { get; set; }
    }

    public class Measure
    {
        [Key()]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Product {get; set;}
    }

    public class ProductType
    {
        [Key()]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Product { get; set; }

    }
}