using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using NissanCartTest01.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin,clerk")]
    public class AppointCalController : Controller
    {
        // GET: AppointCal
        
        private ApplicationDbContext db = new ApplicationDbContext();
      
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            return View(scheduler);
        }


        public ContentResult Data()
        {
            var apps = db.Appointments.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Appointment>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        db.Appointments.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = System.Data.Entity.EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}