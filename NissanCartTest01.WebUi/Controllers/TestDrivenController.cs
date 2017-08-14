using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;
using System.Data.Entity;
using System.Net;
using System.Data;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin,fman")]
    public class TestDrivenController : Controller
    {

        // GET: TestDriven
        ApplicationDbContext cs = new ApplicationDbContext();
        public ActionResult GetJobDriveCards()
        {

            
            var foreman = cs.Foremens
                    .FirstOrDefault(x => x.username.Equals(User.Identity.Name));

           

                var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "Done" && x.ForemanId == foreman.ForemanId);
         
                return View(JobCards);
            
        }
        public ActionResult GetJobCardDriveDetails(int id)
        {
            Tuple<JobCard, Service, IEnumerable<Comment>> JobModel = null;
            var jobCard = cs.JobCards.Include(x => x.Vehicle)
                .FirstOrDefault(x => x.JobCardId == id);



            if (jobCard != null)
            {
                var service = cs.Services.FirstOrDefault(x => x.JobCardId == jobCard.JobCardId);

                var comments = cs.Comments.Where(x => x.JobCardId == jobCard.JobCardId);

                JobModel = new Tuple<JobCard, Service, IEnumerable<Comment>>(jobCard, service, comments);

            }

            return View(JobModel);
        }
        //public ActionResult CreateServiceCard(int id)
        //{

        //    var service=cs.Services.FirstOrDefault(x=>x.JobCardId==id);


        //    if (service != null)
        //    {


        //        cs.Services.Add(service);
        //        cs.SaveChanges();

        //    }
        //    //return RedirectToAction("GetJobCardDetails", "JobCard", new { id = id });
        //    return Json(new { ok = true, newurl = Url.Action("GetJobCardDeatils") });
        //}
        //public ActionResult SaveDriveDetails(int id, string ps, string rs)
        //{
        //    //var jobCard = cs.JobCards.FirstOrDefault(x => x. == id);


        //    var service = cs.Services.FirstOrDefault(x => x.ServiceID == id);
        //    if (service != null)
        //    {
        //        var job = cs.JobCards.FirstOrDefault(c => c.JobCardId == service.JobCardId);
        //        service.Pass = ps;
        //        service.Reason = rs;

        //        cs.SaveChanges();
        //    }
        //    return RedirectToAction("GetJobCards", "JobCard");
        //}

        [HttpPost]
        public ActionResult SaveDriveDetails(int id, string txtPass, string txtReason)
        {
            //var jobCard = cs.JobCards.FirstOrDefault(x => x. == id);

            var service = cs.Services.FirstOrDefault(x => x.JobCardId == id);
            if (service != null)
            {
                var job = cs.JobCards.FirstOrDefault(c => c.JobCardId == service.JobCardId);
                service.Pass = txtPass;
                if (txtPass.ToUpper() == "Yes")
                {
                    job.Progress = "Test-Driven";
                }
                else
                {
                    job.Progress = "Recall";
                }
                service.Reason = txtReason;
                cs.SaveChanges();
            }
            return RedirectToAction("GetJobDriveCards", "TestDriven");
        }

    }
}