using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NissanCart.Domain.Abstract;
using NissanCart.Domain.Entities;

namespace NissanCart.Domain.Concrete
{
    public class EFSalesRespository : ISalesRespository
    {

        private readonly NissanContext context= new NissanContext(); 
        public IEnumerable<Sales> Sales
        {
            

            get { return context.Sales; }
        }
    }
}
