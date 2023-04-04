using Discount.Grpc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
   public interface IDiscountRepository
    {
        Task<ProductDiscount> GetProductDiscountByName(string productname);      
        void CreateProduct(ProductDiscount product);
        bool UpdateProduct(ProductDiscount product);
        bool DeleteProduct(string id);


    }
}
