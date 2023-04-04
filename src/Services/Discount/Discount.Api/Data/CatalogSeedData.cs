using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.API.Entities;
using MongoDB.Driver;

namespace Discount.API.Data
{
    public class CatalogSeedData
    {
        public static void SeedData(IMongoCollection<ProductDiscount> productCollection)
        {
            bool productExist = productCollection.Find(a=> true).Any();
            if(!productExist)
            {
                productCollection.InsertMany(InitialData());
            }
        }

        private static IEnumerable<ProductDiscount> InitialData()
        {
            List<ProductDiscount> productdiscounts = new List<ProductDiscount>();
            productdiscounts.Add(new ProductDiscount() { Name = "TV", Description="Television Discount",  Discount=1000 });
            return productdiscounts;
        }
    }
}
