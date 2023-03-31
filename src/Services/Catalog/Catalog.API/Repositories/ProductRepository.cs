using Catalog.API.Data;
using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IDbContext _dbContext { get; }
        public ProductRepository(IDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public void CreateProduct(Product product)
        {
            _dbContext.products.InsertOne(product);
        }

        public bool DeleteProduct(string id)
        {
            var deleteResult = _dbContext.products.DeleteOne(filter: x => x.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return _dbContext.products.Find(x => x.Category == category).ToList();
        }

        public Product GetProductById(string id)
        {
            return _dbContext.products.Find(x => x.Id == id).FirstOrDefault();
        }

        public Product GetProductByName(string Name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Name, Name);
            //return _dbContext.products.Find(x => x.Name == Name).FirstOrDefault();
            return _dbContext.products.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            var result = _dbContext.products.Find(x => true).ToList();
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            var updateResult = _dbContext.products.ReplaceOne(filter: x => x.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
