using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingGlasses.Models;
using MVC_ShoppingGlasses.ViewModel;
using MVC_ShoppingGlasses.Controllers;
using System.Data.Entity;

namespace MVC_ShoppingGlasses.Controllers
{
    public class CheckoutController : Controller
    {

        // GET: Checkout
        public ActionResult Index()
        {
            OrderViewModel od = new OrderViewModel();
            List<CartItemModel> lst = (List<CartItemModel>)Session["ShoppingCart"];

            Customer customer = new Customer();
            customer = (Customer)Session["CustomerSession"];
            od.Name = customer.Name;
            od.Address = customer.Address;
            od.OrderDate = DateTime.Now;
            od.State = "Chờ Duyệt";
            od.CustomerID = customer.CustomerID;
            od.PhoneNumber = customer.PhoneNumber;
            foreach (CartItemModel item in (List<CartItemModel>)Session["ShoppingCart"])
            {
                od.Total += item.Quantity * item.Product.Price;
            }
            return View(od);
        }

        // thanh toan submit
        [HttpPost]
        public ActionResult Index(OrderViewModel orderViewModel)
        {
            Order order = new Order();
            OrderDatail orderDatail = new OrderDatail();
            var a = orderViewModel.Name.TrimEnd();
            var b = orderViewModel.State;
            try
            {
                using (var db = new SalesGlassesDataContext())
                {
                    order.Name = orderViewModel.Name;
                    order.OrderDate = orderViewModel.OrderDate;
                    order.State = orderViewModel.State;
                    order.Address = orderViewModel.Address;
                    order.PhoneNumber = orderViewModel.PhoneNumber;
                    order.Total = orderViewModel.Total;
                    order.Customers_CustomerID = orderViewModel.CustomerID;
                    order.Total = orderViewModel.Total;
                    db.Orders.Add(order);
                    int i = db.SaveChanges();

                    foreach (CartItemModel item in (List<CartItemModel>)Session["ShoppingCart"])
                    {
                        decimal total = item.Quantity * item.Product.Price;
                        orderDatail.OrderId = order.OrderId;
                        orderDatail.Quantity = item.Quantity;
                        orderDatail.Product_ProductID = item.Product.ProductID;
                        orderDatail.UnitPrice = item.Product.Price;
                        db.OrderDatails.Add(orderDatail);
                        db.SaveChanges();
                    }

                    UpDateProductQuantity();
                    Session["ShoppingCart"] = null;
                    return RedirectToAction("Index","Home");

                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }



        }
        public void UpDateProductQuantity()
        {
            using (var db = new SalesGlassesDataContext())
            {

                foreach (CartItemModel cartItem in (List<CartItemModel>)Session["ShoppingCart"])
                {
                    Product product = new Product();
                    product = db.Products.FirstOrDefault(e => e.ProductID == cartItem.Product.ProductID);
                    if (product != null)
                    {
                        product.Unitinstock = product.Quantity - cartItem.Quantity;
                        if (product.Unitinstock == 0)
                        {
                            product.State = "Hết hàng";
                        }
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }
     
    }
}