using AutoMapper;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountServices: DiscountProtoService.DiscountProtoServiceBase
    {
        private IDiscountRepository _discountRepository { set; get; }
        private ILogger<DiscountServices> _logger { set; get; }
        private IMapper _mapper { set; get; }
        public DiscountServices(ILogger<DiscountServices> logger,IDiscountRepository discountRepository,IMapper mapper)
        {
            _discountRepository = discountRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<ProductDiscount> GetDiscount(GetDiscountReq request, ServerCallContext context)
        {
            var discount =await _discountRepository.GetProductDiscountByName(request.Productname);
            if(discount==null)
            {
                throw new RpcException( new Status(StatusCode.NotFound, $"No discount found for the product {request.Productname}"));
            }
            var productDiscount = _mapper.Map<ProductDiscount>(discount);
            _logger.LogInformation($"The discount for the product {productDiscount.Name} is {productDiscount.Discount}");
            return productDiscount;

        }

        public override Task<ProductDiscount> CreateDiscount(CreateDiscountReq request, ServerCallContext context)
        {
            var productDiscount = _mapper.Map<Discount.Grpc.Entities.ProductDiscount>(request.Discount);
            _discountRepository.CreateProduct(productDiscount);
            _logger.LogInformation("Discount created successfully");
            return null;
        }

        public override Task<ProductDiscount> UpdateDiscount(UpdateDiscountReq request, ServerCallContext context)
        {
            var productDiscount = _mapper.Map<Discount.Grpc.Entities.ProductDiscount>(request.Discount);
            var isUpdated=  _discountRepository.UpdateProduct(productDiscount);
            string updateResult = isUpdated ? "Sucess" : "Failed";
            _logger.LogInformation($"Discount updated {updateResult} for product {request.Discount.Description}");
            return null;
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountReq request, ServerCallContext context)
        {
            var productDiscount = _mapper.Map<Discount.Grpc.Entities.ProductDiscount>(request.Discount);
            var isUpdated = _discountRepository.DeleteProduct(productDiscount.Id);
            string updateResult = isUpdated ? "Sucess" : "Failed";
            _logger.LogInformation($"Discount deleted {updateResult} for product {request.Discount.Description}");
            return null;
        }
    }
}
