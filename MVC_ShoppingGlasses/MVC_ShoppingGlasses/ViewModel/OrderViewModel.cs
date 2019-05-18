using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ShoppingGlasses.ViewModel
{
    public class OrderViewModel
    {

        public DateTime OrderDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(40)]
        public string State { get; set; }

        [Required]
        [StringLength(40)]
        [Phone]
        public string PhoneNumber { get; set; }
        public int CustomerID { get; set; }

        public decimal Total { get; set; }


        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int? Product_ProductID { get; set; }

        List<CartItemModel> cartItemModels { get; set; }

    }
}