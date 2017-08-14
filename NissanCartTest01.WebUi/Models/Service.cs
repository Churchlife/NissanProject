using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        //public string Comments { get; set; }
        public string Pass { get; set; }
        public string Reason { get; set; }
        public int StaffID { get; set; }
        public int JobCardId { get; set; }
        public virtual JobCard JobCard { get; set; }

    }
}