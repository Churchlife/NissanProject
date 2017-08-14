using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class BookIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string RegId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Time { get; set; }


        [StringLength(60)]
        public string Status { get; set; }
    }
}