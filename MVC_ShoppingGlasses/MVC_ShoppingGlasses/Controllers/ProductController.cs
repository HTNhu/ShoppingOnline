
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
namespace MVC_ShoppingGlasses.Controllers
{
    public class ProductController : Controller
    {
         SalesGlassesDataContext db = new SalesGlassesDataContext();
        // GET: Product
        public ViewResult Index()
        {
            
            return View("Index",db.Products.ToList());
        }
        
        public ViewResult ListProductByCategory(int categoryID)
        {

            return View("Index",db.Products.Where(e=>e.CategoryID== categoryID).ToList());
        }
        //Get


        public ActionResult ProductDetail(int id)
        {
 
            return View(db.Products.FirstOrDefault(e=>e.ProductID == id));
        }
        [HttpPost]
        public ViewResult Search(FormCollection frm)
        {
            string[] s = frm.GetValues("txtsearch") ;
            string text = s[0];

            return View("Index",db.Products.Where(e => e.Name.Contains(text)).ToList());
        }


    }
}