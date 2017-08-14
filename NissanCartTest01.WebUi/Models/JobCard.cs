using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class JobCard
    {
        [Column(Order = 0), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCardId { get; set; }

        public string Techfaults { get; set; }
        public string Userfaults { get; set; }
        [Required]
        public string Possession { get; set; }
        public decimal Price { get; set; }

        public string Progress { get; set; }

        public virtual List<Comment> Commentts { get; set; }

        //public virtual List<StandardFault> StanFaults{ get; set; }

        public string RegId { get; set; }
        public string VinNumber { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public int ForemanId { get; set; }

        public virtual Foremen Foreman { get; set; }
        
    }
}