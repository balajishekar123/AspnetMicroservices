using Discount.Grpc.Data;
using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private IDbContext _dbContext { get; }
        public DiscountRepository(IDbContext dbContext)
        {
           _dbContext = dbContext;
        }        

        public async Task<ProductDiscount> GetProductDiscountByName(string productname)
        {
            return await _dbContext.productDiscounts.Find(x => x.Name == productname).FirstOrDefaultAsync();
        }

        public void CreateProduct(ProductDiscount product)
        {
            _dbContext.productDiscounts.InsertOne(product);
        }

        public bool UpdateProduct(ProductDiscount product)
        {
            var updateResult = _dbContext.productDiscounts.ReplaceOne(filter: x => x.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public bool DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }
    }
}
