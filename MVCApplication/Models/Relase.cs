using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAplication.Models
{
    public class Release
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public string  Description { get; set; }
        public double Value{ get; set; }

        public ReleaseType Type { get; set; }
        public ReleaseStatus Status { get; set; }

    }

    public enum ReleaseType
    {
        [Description("Cash In")]
        Entrada,
        [Description("Cash Out")]
        Saida
    }
    public enum ReleaseStatus
    {
        Pending,
        Made
    }
}