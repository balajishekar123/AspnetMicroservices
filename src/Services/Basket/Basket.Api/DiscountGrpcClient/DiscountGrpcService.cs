using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Discount.Grpc.Protos;

namespace Basket.Api.DiscountGrpcClient
{
    public class DiscountGrpcService
    {
        private DiscountProtoService.DiscountProtoServiceClient _discountProtoService { set; get; }
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoService = discountProtoServiceClient;
        }

        public async Task<ProductDiscount> GetProductDiscount(string name)
        {
            var discountReques = new GetDiscountReq { Productname = name };
            var discount =await _discountProtoService.GetDiscountAsync(discountReques);
            return discount;
        }
    }
}
