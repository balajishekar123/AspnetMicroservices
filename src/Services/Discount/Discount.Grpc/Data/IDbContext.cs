using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.Grpc.Entities;
using MongoDB.Driver;

namespace Discount.Grpc.Data
{
    public interface IDbContext
    {
       IMongoCollection<ProductDiscount> productDiscounts {  get; }
    }
}
