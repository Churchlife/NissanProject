using NissanCart.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class SalesController : Controller
    {
        // GET: Sales



        //Adding a private instant
        private readonly ISalesRespository repository;


        //Constructor 
        public SalesController(ISalesRespository repo)
        {
            repository = repo;



        }





            //View result as a List
        public ViewResult List()
        {

            return View(repository.Sales);

        }

    }
}