using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogSeedData
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool productExist = productCollection.Find(a=> true).Any();
            if(!productExist)
            {
                productCollection.InsertMany(InitialData());
            }
        }

        private static IEnumerable<Product> InitialData()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Name = "TV", Category = "Entertainment", Description="Television", ImageFile="TV.jpg", Price=30000 });
            return products;
        }
    }
}
