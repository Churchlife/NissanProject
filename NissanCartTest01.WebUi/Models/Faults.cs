using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Faults
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FaultId { get; set; }
        public string Category { get; set; }
        public string Fault { get; set; }
        public bool Checked { get; set; }
        public decimal Price { get; set; }
        public decimal p { get; set; }
    }

    public class FaultList
    {
        [Key]
        public int flId { get; set; }
        public List<Faults> faults { get; set; }
        public string UserFaults { get; set; }
        public string TechFaults { get; set; }

        public int JobCardnum { get; set; }
        public string Regnum { get; set; }
    }
}
