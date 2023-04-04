using Basket.Api.DiscountGrpcClient;
using Basket.Api.Entities;
using Basket.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketRepository _basketRepository { set; get; }
        private DiscountGrpcService _discountGrpcService { set; get; }
        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService )
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)StatusCodes.Status200OK)]
        public  async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket =await _basketRepository.GetShoppingCart(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart cart)
        {
            foreach(var item in cart.cartItems)
            {
                var itemDiscount =await _discountGrpcService.GetProductDiscount(item.ProductName);
                if (itemDiscount != null)
                    item.Price = item.Price - (Decimal)itemDiscount.Discount;
            }
            var result = await _basketRepository.UpddateBasket(cart);
            return Ok(result);
        }

        
        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            await _basketRepository.DeleteBasket(username);
            return Ok();
        }
    }
}
