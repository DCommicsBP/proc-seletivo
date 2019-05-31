using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string  Name{ get; set; }
        public string  Description { get; set; }
        public float Value { get; set; }
        public double quantity { get; set; }
        public int MeasureID { get; set; }
        public int ProductTypeID { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual ProductType ProductType { get; set; }
    }

    public class Measure
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Product Product {get; set;}
    }

    public class ProductType
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}