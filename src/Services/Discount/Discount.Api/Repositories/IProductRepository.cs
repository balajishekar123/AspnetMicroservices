using Discount.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
   public interface IDiscountRepository
    {
        ProductDiscount GetProductDiscountByName(string productname);      
        void CreateProduct(ProductDiscount product);
        bool UpdateProduct(ProductDiscount product);
        bool DeleteProduct(string id);


    }
}
