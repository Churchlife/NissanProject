using Microsoft.AspNet.Identity.EntityFramework;
using NissanCartTest01.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;


        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            try
            {

                context.Roles.Add(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: /Account/Login
        public ActionResult Assign(string returnUrl)
        {
                var Users = context.Users.ToList();
                return View(Users);
            
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
