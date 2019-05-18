using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVC_ShoppingGlasses.Models;
namespace MVC_ShoppingGlasses.ViewModel
{
    [Serializable]
   public class CartItemModel
    {
        [RegularExpression("[1-9]",ErrorMessage ="Please enter a numeric")]
        [Required(ErrorMessage ="Quantity is required")]

        public int Quantity { get; set; }
        public   Product Product { get; set; }
        

    }
}
