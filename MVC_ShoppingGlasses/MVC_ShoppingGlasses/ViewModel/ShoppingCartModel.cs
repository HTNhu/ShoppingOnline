using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_ShoppingGlasses.ViewModel
{
    [Serializable]
    
    public  class ShoppingCartModel
    {
        public List<CartItemModel> cartItemModels;
        public decimal total;
    }
}
