using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Vehicle
    {

        [Key, Column(Order = 0)]
        [StringLength(17)]
        [Required]
        public string VinNumber { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string RegId { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }
        [Required]
        //[Range(1800, 2018)]
        public int Year { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        //[Range(1, 800000)]
        public int Mileage { get; set; }
        [Required]
        public string ID_Number { get; set; }
        public virtual Customer Customer { get; set; }
        
    }
}