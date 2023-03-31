using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public string _username { get; set; }
        public List<ShoppingCartItem> cartItems { set; get; }

        public decimal TotalPrice {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in cartItems)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }
        public ShoppingCart()
        {

        }
        public ShoppingCart(string username)
        {
            _username = username;
        }
    }
}
