using Basket.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetShoppingCart(string username);
        Task<ShoppingCart> UpddateBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string username);

    }
}
