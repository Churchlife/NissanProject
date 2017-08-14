using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    public class UsersController : Controller
    {
        [Authorize(Roles = "admin")]
        // GET: Users
        public ActionResult ManagerIndex()
        {
            return View();
        }
        [Authorize(Roles = "admin,clerk")]
        public ActionResult ManagerIndexSC()
        {
            return View();
        }
        [Authorize(Roles = "admin,advice")]
        public ActionResult ManagerIndexSA()
        {
            return View();
        }
        [Authorize(Roles = "admin,tech")]
        public ActionResult ManagerIndexST()
        {
            return View();
        }
        [Authorize(Roles = "admin,fman")]
        public ActionResult ManagerIndexSF()
        {
            return View();
        }

        public ActionResult AdvisorIndex()
        {
            return View();
        }

        public ActionResult ClerkIndex()
        {
            return View();
        }

        public ActionResult TechIndex()
        {
            return View();
        }

        public ActionResult ForemanIndex()
        {
            return View();
        }

    }
}