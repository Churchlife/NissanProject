using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using NissanCartTest01.WebUi.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(NissanCartTest01.WebUi.Startup))]
namespace NissanCartTest01.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        
    }

    
}
