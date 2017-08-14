using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Staff
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        //[Key, Column(Order = 1)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string username { get; set; }
        public List<JobCard> JobCards { get; set; }

        //[Authorize(Roles = "staff, admin")]
    }
}