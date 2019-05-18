using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
using MVC_ShoppingGlasses.ViewModel;

namespace MVC_ShoppingGlasses.Areas.Employee.Controllers
{
    public class LoginController : Controller
    {
        // GET: Employee/Login
        public ActionResult Index()
        {
            return View();
        }
        // Tim ACountID
        public Account GetAccountByUserName(String username)
        {
            using (var db = new SalesGlassesDataContext())
            {
                var acc = db.Accounts.FirstOrDefault(e => e.UserName == username);
                if (acc != null)
                {
                    return acc;
                }
                return null;
            }
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var acc = GetAccountByUserName(login.UserName);
                using (var db = new SalesGlassesDataContext())
                {
                    var e = db.Employees.ToList();
                    foreach (MVC_ShoppingGlasses.Models.Employee emp in e)
                    {
                        if (emp.EmployeeID == acc.AccID)
                        {
                            if (login.Password == acc.Password)
                            {
                               
                                return RedirectToAction("Index", "HomeEmployee");
                            }
                        }
                    }
                    return View(login);
                }
            }
            return View(login);
        }

    }
}