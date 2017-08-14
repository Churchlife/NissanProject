using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Customer
    {

        [Key]
        [Required]
        [MaxLength(14)]
        [MinLength(1)]
        [RegularExpression("[0-9]*$",ErrorMessage ="ID must be in Numerics")]
        public string ID_Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        //[RegularExpression(@"^[A_Z]+[a-z A-Z''-'\S]*$")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Physical_Address { get; set; }
        public string Postal_Address { get; set; }
    }
}