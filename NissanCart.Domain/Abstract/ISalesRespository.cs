using NissanCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NissanCart.Domain.Abstract
{
   public interface ISalesRespository
    {

        IEnumerable<Sales> Sales { get; }
          
              
    }
}
