using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Entities;
using MongoDB.Driver;

namespace Discount.API.Data
{
    public interface IDbContext
    {
       IMongoCollection<ProductDiscount> productDiscounts {  get; }
    }
}
