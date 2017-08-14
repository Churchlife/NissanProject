using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NissanCart.Domain.Entities;

namespace NissanCart.Domain.Concrete
{
    public class NissanContext:DbContext
    {

        public DbSet<Sales> Sales { get; set; }

                

    }

}
