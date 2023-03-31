using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(string id);
        Product GetProductByName(string Name);
        IEnumerable<Product> GetProductByCategory(string category);
        void CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(string id);


    }
}
