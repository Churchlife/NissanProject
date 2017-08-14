using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    public class EmailController : Controller
    {
        [Authorize(Roles = "admin, advice")]
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Form()
        {
            return View();




        }

        [HttpPost]
        public ActionResult Form(string receiverEmail, string subject, string message)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var senderemail = new MailAddress("vijay.manikkam766@gmail.com", "DemoTest");
                    var receiveremail = new MailAddress(receiverEmail, "Receiver");
                    var password = "Tar766Zan97";
                    var sub = subject;
                    var body = message;


                    var smtp = new SmtpClient
                    {

                        Host = "smtp.gmail.com	",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)

                    };


                    using (var mess = new MailMessage(senderemail, receiveremail)
                    {
                        Subject = subject,
                        Body = body,
                    }
                    )
                    {
                        smtp.Send(mess);
                    }

                }

                return ViewBag();



            }
            catch (Exception)
            {
                ViewBag.Error = " email Sent";


            }





            return View();
        }

    }
}