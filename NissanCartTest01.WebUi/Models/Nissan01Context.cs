using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class Nissan01Context:DbContext

    {

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Manager> Managers { get; set; }

       
    }
}