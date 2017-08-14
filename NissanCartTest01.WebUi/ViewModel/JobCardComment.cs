using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.ViewModel
{
    public class JobCardComment
    {
        public int id { get; set; }
        public int? parent { get; set; }

        public string created { get; set; }

        public string fullname { get; set; }

        public string content { get; set; }

        public string modified { get; set; }
    }
}