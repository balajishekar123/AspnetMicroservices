using AutoMapper;
using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile: Profile
    {
        public DiscountProfile()
        {
            CreateMap<ProductDiscount, Discount.Grpc.Protos.ProductDiscount>().ReverseMap();
        }
    }
}
