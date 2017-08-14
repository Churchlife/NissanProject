using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Comment
    {
        


        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        public int? Parent { get; set; }

        public string created { get; set; }

        public string fullname { get; set; }

        public string content { get; set; }

        public string modified { get; set; }

        public int JobCardId { get; set; }

        public virtual JobCard JobCard { get; set; }

    }
}