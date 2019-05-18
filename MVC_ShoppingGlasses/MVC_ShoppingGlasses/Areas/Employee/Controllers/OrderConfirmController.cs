using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
using MVC_ShoppingGlasses.ViewModel;

namespace MVC_ShoppingGlasses.Areas.Employee.Controllers
{
    public class OrderConfirmController : Controller
    {
        SalesGlassesDataContext db = new SalesGlassesDataContext();
        [HttpGet]
        public ActionResult OrderConfirm()
        {
            String tinhtrang = "Chờ Duyệt";
            using (var db = new SalesGlassesDataContext())
            {
                List<Order> lst = new List<Order>();
                return View(lst = db.Orders.Where(e => e.State == tinhtrang).ToList());
            }
        }
    
        [HttpGet]
        public ActionResult OrderDetail(int id)
        {
            var db = new SalesGlassesDataContext();
            return PartialView("OrderDetailPartial", db.OrderDatails.Where(e => e.OrderId == id).ToList());

        }
        //Thay doi tinh trang 
        public ActionResult ChangeState(int id)
        {
            String tinhtrang = "Đã Duyệt";
            using (var db = new SalesGlassesDataContext())
            {
                var ord = db.Orders.FirstOrDefault(e => e.OrderId == id);
                ord.State = tinhtrang;
                db.SaveChanges();
                return View("OrderConfirm", db.Orders.Where(e => e.State == "Chờ Duyệt").ToList());
            }
        }
    }
}