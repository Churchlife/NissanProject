using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class Manager
    {

        [Key]
        public int MangerId { get; set; }

        public string Username { get; set; }

        public string Creditials  { get; set; }

        public string Password { get; set; }


        public int StaffId { get; set; }

        public string DealInfo { get; set; }

        public string VehicleInfo { get; set; }
        public decimal AmountP { get; set; }

        public int CustomerID { get; set; }

        public string Comments { get; set; }
    }
}