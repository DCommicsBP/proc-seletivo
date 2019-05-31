using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool Debtor { get; set; }

        public virtual IEnumerable<Sales> Sales { get; set; }

    }

}