using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
using MVC_ShoppingGlasses.ViewModel;
namespace MVC_ShoppingGlasses.Controllers

{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                using (var db = new SalesGlassesDataContext())
                {
                    var acc = db.Accounts.FirstOrDefault(e => e.UserName == register.UserName.TrimEnd());
                    if (acc == null)
                    {
                        Account account = new Account();
                        account.UserName = register.UserName;
                        account.Password = register.Password;
                        db.Accounts.Add(account);
                        db.SaveChanges();
                        Customer customer = new Customer();
                        customer.Name = register.Name.TrimEnd();
                        customer.Gender = register.Gender;
                        customer.PhoneNumber = register.PhoneNumber;
                        customer.Address = register.Address;
                        customer.CustomerID = account.AccID;
                        db.Customers.Add(customer);
                        db.SaveChanges();
                        return View(register);

                    }
                    else
                    {
                        ModelState.AddModelError("Username", "username đã tồn tại");

                        return View(register);
                    }
                }
            }
            else
            {
                return View(register);
            }
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
        //
        public Customer GetCustomerByID(int id)
        {
            using (var db = new SalesGlassesDataContext())
            {
                var customer = db.Customers.FirstOrDefault(e => e.CustomerID==id );
                if (customer != null)
                {
                    return customer;
                }
                return null;
            }
        }

        //Get : Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            var sescus = Session["CustomerSession"];
            if (ModelState.IsValid)
            {
                var acc = GetAccountByUserName(login.UserName.TrimEnd());
                using (var db = new SalesGlassesDataContext())
                {
                    var cus = db.Customers.ToList();
                    foreach (Customer customer in cus)
                    {
                        if (customer.CustomerID == acc.AccID)
                        {
                            if (login.Password == acc.Password.TrimEnd())
                            {
                                if (Session["CustomerSession"] == null)
                                {
                                    Customer c = new Customer();
                                    c = GetCustomerByID(acc.AccID);   
                                    Session["CustomerSession"] = c;
                                }
                                else
                                {
                                    return RedirectToAction("Index", "Product");
                                }
                                return RedirectToAction("Index", "Home");
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