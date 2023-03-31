using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private IDistributedCache _redisCache { set; get; }
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;

        }
        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }

        public  async Task<ShoppingCart> GetShoppingCart(string username)
        {
            var basket =await _redisCache.GetStringAsync(username);
            if (string.IsNullOrEmpty(basket.ToString()))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpddateBasket(ShoppingCart shoppingCart)
        {
            await _redisCache.SetStringAsync(shoppingCart._username, JsonConvert.SerializeObject(shoppingCart));
            return await GetShoppingCart(shoppingCart._username);
        }
    }
}
