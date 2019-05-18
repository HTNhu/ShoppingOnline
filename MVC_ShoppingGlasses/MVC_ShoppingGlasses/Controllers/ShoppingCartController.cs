using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
using MVC_ShoppingGlasses.ViewModel;
namespace MVC_ShoppingGlasses.Controllers
{
    public class ShoppingCartController : Controller
    {
        SalesGlassesDataContext db = new SalesGlassesDataContext();
        // GET: ShoppingCart
        public ActionResult ShowMyCart()
        {

            var cart = Session["ShoppingCart"];
            List<CartItemModel> lst = new List<CartItemModel>();
            if (cart != null)
            {
                lst = (List<CartItemModel>)cart;
            }
            else
            {
                ViewBag.Empty = "Không có sản phẩm nào trong giỏ hàng";
            }

            return View("ShowMyCart", lst);
        }
        public ActionResult AddToCart(int proID)
        {
            Product pro = db.Products.FirstOrDefault(e => e.ProductID == proID);
            CartItemModel cartItem = new CartItemModel();


            if (Session["ShoppingCart"] == null)
            {
                List<CartItemModel> lstItem = new List<CartItemModel>();
                cartItem.Product = pro;
                cartItem.Quantity = 1;
                lstItem.Add(cartItem);
                Session["ShoppingCart"] = lstItem;
            }
            else
            {
                List<CartItemModel> lstItem = (List<CartItemModel>)Session["ShoppingCart"];
                int index = CheckCartItem(proID);
                if (index != -1)
                {
                    lstItem[index].Quantity += 1;
                }
                else
                {
                    cartItem.Product = pro;
                    cartItem.Quantity = 1;
                    lstItem.Add(cartItem);
                }
                Session["ShoppingCart"] = lstItem;
            }
            return RedirectToAction("Index","Product");

        }

        
        public int CheckCartItem(int id)
        { 
            List<CartItemModel> lstItem = (List<CartItemModel>)Session["ShoppingCart"];
            for(int i = 0; i< lstItem.Count;i++ )
            {
                if (lstItem[i].Product.ProductID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        //[ChildActionOnly]
        public ViewResult UpdateCart(FormCollection form)
        {
            List<CartItemModel> lstItem = (List<CartItemModel>)Session["ShoppingCart"];
            string[] quantity = form.GetValues("quantity");
        
           for (int i = 0; i < lstItem.Count; i++)
            {
                lstItem[i].Quantity = Int32.Parse(quantity[i]);


            }
            Session["ShoppingCart"] = lstItem;
            return View("ShowMyCart",lstItem);
        }
        public ViewResult DeleteCartItem(int proID)
        {
            List<CartItemModel> lstItem = (List<CartItemModel>)Session["ShoppingCart"];
   
            for (int i = 0; i < lstItem.Count; i++)
            {
                lstItem[i].Product.ProductID = proID;
                lstItem.Remove(lstItem[i]);
                break;
            }
            Session["ShoppingCart"] = lstItem;
            return View("ShowMyCart",lstItem);
        }

    }
}