using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.ViewModel;
using MVC_ShoppingGlasses.Models;
namespace MVC_ShoppingGlasses.Controllers
{
    public class HomeController : Controller
    {
        SalesGlassesDataContext db = new SalesGlassesDataContext();
        public ActionResult Index()
        {
            return View("Index", db.Products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult  MyCart()
        {
            var cart = Session["ShoppingCart"];
            List<CartItemModel> lst = new List<CartItemModel>();
                if(cart != null)
            {
                lst = (List<CartItemModel>)cart;
            }

            return PartialView("MyCart",lst);
        }
        [ChildActionOnly]
        public PartialViewResult ListCategory()
        {
           

            return PartialView("ListCategory", db.Categories.ToList());
        }
        [ChildActionOnly]
        public PartialViewResult MyAcc()
        {
            Customer c = new Customer();
            if (Session["CustomerSession"] != null)
            {
                c = (Customer)Session["CustomerSession"];
            }
            else
            {
                c = null;
            }
            return PartialView("MyAcc", c);
        }
        // Tim kiem san pham
        public ActionResult Search(String searching)
        {
            return View("Index",db.Products.Where(e=>e.Name.Contains(searching) || searching == null).ToList());
        }
    }
}