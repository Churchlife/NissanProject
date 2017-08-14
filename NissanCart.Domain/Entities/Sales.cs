using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NissanCart.Domain.Entities
{
   public class Sales
    {



        public int StaffId { get; set; }
        public string DealInfo { get; set; }

        public string VehicleInfo { get; set; }

        public decimal AmountPaid { get; set; }

        public string StaffInfo { get; set; }

        public int CUstomerID { get; set; }


        public string Comment { get; set; }

    }

}
