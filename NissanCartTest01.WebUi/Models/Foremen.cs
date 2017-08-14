using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Foremen
    {
        [Key]
        public int ForemanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string username { get; set; }
        public List<JobCard> JobCards { get; set; }
    }
}