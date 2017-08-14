using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;
using System.Data.Entity;
using System.Text;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin,advice")]
    public class FaultsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Faults
        public ActionResult Index()
        {
            List<Faults> FL = new List<Faults>();


            FL.Add(new Faults() { Category = "Under Bonnet", Fault = "Accelerator Operation", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Bonnet", Fault = "Engine Performance", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Bonnet", Fault = "Battery load test", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Bonnet", Fault = "Condition of Spark plugs", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Bonnet", Fault = "Condition of engine oil & level", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Body", Fault = "Condition of ball joints", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Body", Fault = "Condition of brake disks & drums", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Body", Fault = "Inspect wheel alignment, if necessary rotate & balance", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Body", Fault = "Condition of CV joints & boots", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Under Body", Fault = "Check for exhaust leaks", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "External Condition", Fault = "Condition of exterior lights and operations", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "External Condition", Fault = "Condition of front & rear wiper blade & operation", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "External Condition", Fault = "Condition of windscreen chips/cracks", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "External Condition", Fault = "Whells-Condition of mags/rims/hubcaps", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "External Condition", Fault = "Operation of Jack & tools", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Internal Condition", Fault = "Air conditioner operation", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Internal Condition", Fault = "Operation of air vents and fan", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Internal Condition", Fault = "Operation of guages & speedo", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Internal Condition", Fault = "Check hooter operation", Checked = false, Price = 100 });
            FL.Add(new Faults() { Category = "Internal Condition", Fault = "Condition of upholstery", Checked = false, Price = 100 });

            FaultList fltlist = new FaultList();
            fltlist.faults = FL;
            return View(fltlist);
        }

        [HttpPost]
        public ActionResult Index(FaultList frl)
        {

            StringBuilder sb = new StringBuilder();
            //JobCard j = new JobCard();
            // sb.Append("Faults:");
            //JobCard j = new JobCard();
            List<JobCard> jl = new List<JobCard>();
            foreach (var item in frl.faults)
            {
                if (item.Checked)
                {
                    sb.Append(item.Fault + ",");
                    //item.p = item.p + item.Price;



                }
            }
            //FaultList f = new FaultList();
            //int max = db.JobCards.Max(p => p.JobCardId);

            //foreach (JobCard search in jl)
            //{
            //    if (search.TechFaults == null)
            //    {
            //        j.JobCardId = 122;
            //        j.RegId = "ND 1";
            //        j.UserFaults = "Wooo";
            //        j.TechFaults = sb.ToString();
            //        db.JobCards.Add(j);
            //    }
            //}


            //List<JobCards> companiesWithEmployees = db.JobCards.ToList();
            //JobCards ces = JobCards
            //        .Find(x => x.Employees==companiesWithEmployees.R

            //j.JobCardId = max;
            //j.TechFaults = sb.ToString();
            sb.Remove(sb.ToString().LastIndexOf(","), 1);
            //j.TechFaults = sb.ToString();

            //var model = new JobCards()
            //{
            //    TechFaults = sb.ToString()
            //};
            //TempData["ModelName"] = model;
            //StringBuilder st = new StringBuilder();
            //foreach (var item in jl)
            //{
            //    if (item.RegId != null)
            //    {
            //        st.Append(item.RegId + ",");
            //        //item.p = item.p + item.Price;



            //    }
            //}
            JobCard jobCard = Session["jcData"] as JobCard;
            jobCard.Techfaults = sb.ToString();
            ViewBag.selectFault = "selected faults are:" + sb.ToString();





            db.JobCards.Add(jobCard);
            db.SaveChanges();
            return RedirectToAction("GetJobCardsSA", "JobCard");
        }


    }
}