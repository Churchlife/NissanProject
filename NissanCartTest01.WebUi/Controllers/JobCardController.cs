using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;
using System.Data.Entity;
using NissanCartTest01.WebUi.ViewModel;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize]
    public class JobCardController : Controller
    {
        ApplicationDbContext cs = new ApplicationDbContext();

        // GET: JobCard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //    var posses = cs.JobCards.ToList().Find(x => x.Name.ToUpper() == User.Identity.Name);
            ViewBag.StaffId = new SelectList(cs.Staffs, "StaffId", "Name");
            ViewBag.VinNumber = new SelectList(cs.Vehicles, "VinNumber", "VinNumber");
            ViewBag.ForemanId = new SelectList(cs.Foremens, "ForemanId", "Name");
            ViewBag.RegId = new SelectList(cs.Vehicles, "RegId", "RegId");
            return View(/*posses*/);
        }

    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobCardId,Techfaults,Userfaults,Possession,TechnicianName,Price,Progress,RegId,VinNumber,StaffId,ForemanId")] JobCard jobCard)
        {
            if (ModelState.IsValid)
            {
                //cs.JobCards.Add(jobCard);
                //cs.SaveChanges();
                Session["jcData"] = jobCard;
                return RedirectToAction("Index", "Faults");
            }
            ViewBag.ForemanId = new SelectList(cs.Foremens, "ForemanId", "Name", jobCard.ForemanId);
            ViewBag.StaffId = new SelectList(cs.Staffs, "StaffId", "Name", jobCard.StaffId);
            ViewBag.VinNumber = new SelectList(cs.Vehicles, "VinNumber", "VinNumber", jobCard.VinNumber);
            ViewBag.RegId = new SelectList(cs.Vehicles, "RegId", "RegId", jobCard.RegId);
            return View(jobCard);
        }
        public ActionResult GetJobCardsSA()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsSAwaiting()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "Awaiting").ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsSAService()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "In-Service").ToList();

            return View(JobCards);
        }

        public ActionResult GetJobCardsSADone()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "Done").ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsSADriving()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "Test-Driven").ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsSARecall()
        {
            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress == "Recall").ToList();

            return View(JobCards);
        }

        public ActionResult GetJobCards()
        {

            var staff = cs.Staffs
                    .FirstOrDefault(x => x.username.ToUpper()==User.Identity.Name);


            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.StaffId == staff.StaffId && x.Progress == "Awaiting").ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsService()
        {

            var staff = cs.Staffs
                    .FirstOrDefault(x => x.username.ToUpper() == User.Identity.Name);


            var JobCards = cs.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.StaffId == staff.StaffId && x.Progress== "In-Service").ToList();

            return View(JobCards);
        }
        public ActionResult GetJobCardsRecall()
        {
            var staff = cs.Staffs
                    .FirstOrDefault(x => x.username.ToUpper() == User.Identity.Name);

            var s = cs.Services.Include(x => x.JobCard)
                .Include(x => x.JobCard.Vehicle)
                .Where(x => x.JobCard.Progress.ToUpper() == "RECALL" && x.StaffID == staff.StaffId).ToList();

            return View(s);
        }
    
        public ActionResult GetJobCardDetails(int id)
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
        
        [HttpPost]
        public ActionResult CreateServiceCard(int id)
        {

            var jobCard = cs.JobCards.FirstOrDefault(x => x.JobCardId == id);
            if (jobCard != null)
            {
                jobCard.Progress = "In-Service";


                var staff = cs.Staffs
                    .FirstOrDefault(x => x.username.ToUpper() == User.Identity.Name);
                jobCard.Possession = staff.Name;

                var service = new Service
                {
                    StartTime = DateTime.Now,
                    JobCard = jobCard,
                    JobCardId = jobCard.JobCardId,
                    StaffID = jobCard.StaffId
                };
                cs.Services.Add(service);
                cs.SaveChanges();

            }
            //return RedirectToAction("GetJobCardDetails", "JobCard", new { id = id });
            return Json(new { ok = true, newurl = Url.Action("GetJobCardDeatils") });
        }
        [HttpPost]
        public ActionResult SaveEndDate(int id)
        {
            //var jobCard = cs.JobCards.FirstOrDefault(x => x. == id);


            var service = cs.Services.FirstOrDefault(x => x.ServiceID == id);
            if (service != null)
            {
                var job = cs.JobCards.FirstOrDefault(c => c.JobCardId == service.JobCardId);
                job.Progress = "Done";
                service.EndTime = DateTime.Now;
                cs.SaveChanges();
            }
            return RedirectToAction("GetJobCards", "JobCard");
        }

        //public ActionResult ChangeProgress(int id)
        //{
        //    var jobCard = db.JobCards.FirstOrDefault(x => x.JobCardNumber == id);

        //    jobCard.Progress = "Done";

        //    db.SaveChanges();

        //    return RedirectToAction("SaveEndDate(id)");
        //}

        [HttpPost]
        public JsonResult postComment(JobCardComment comment)
        {
            var jobCard = cs.JobCards.FirstOrDefault(x => x.JobCardId == comment.id);

            if (jobCard != null)
            {
                Comment c = new Comment
                {
                    content = comment.content,
                    Parent = comment.parent,
                    modified = comment.modified,
                    created = comment.created,
                    fullname = comment.fullname
                };
                cs.Comments.Add(c);
                jobCard.Commentts.Add(c);
                cs.SaveChanges();
                return Json(comment, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult putComment(int id, JobCardComment comment)
        {
            var user_comment = cs.Comments.FirstOrDefault(x => x.CommentID == id);
            if (user_comment != null)
            {
                user_comment.modified = comment.modified;
                user_comment.content = comment.content;
                user_comment.Parent = comment.parent;
                cs.SaveChanges();

                return Json(/*json*/comment, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getComments(int id)
        {
            var comments = cs.Comments.Where(x => x.JobCardId == id);

            if (comments != null)
            {
                List<JobCardComment> commentsJSON = new List<JobCardComment>();
                foreach (var c in comments)
                {
                    commentsJSON.Add(new JobCardComment
                    {
                        content = c.content,
                        created = c.created,
                        id = c.CommentID,
                        parent = c.Parent,
                        fullname = c.fullname,
                        modified = c.modified
                    });
                }
                return Json(commentsJSON, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
