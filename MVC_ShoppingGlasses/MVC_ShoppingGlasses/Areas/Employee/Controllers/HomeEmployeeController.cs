using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;

namespace MVC_ShoppingGlasses.Areas.Employee.Controllers
{
    public class HomeEmployeeController : Controller
    {

        // GET: Employee/Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult MyAcc()
        {
            Models.Employee c = new Models.Employee();
            if (Session["EmployeeSession"] != null)
            {
                c = (Models.Employee)Session["EmployeeSession"];
            }
            else
            {
                c = null;
            }
            return PartialView("MyAcc", c);
        }
    }
}