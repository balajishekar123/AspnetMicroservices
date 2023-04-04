using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.Grpc.Entities;
using MongoDB.Driver;

namespace Discount.Grpc.Data
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
            productdiscounts.Add(new ProductDiscount() { Name = "Smart Phone", Description= "Smart Phone",  Discount=300 });
            productdiscounts.Add(new ProductDiscount() { Name = "Samsung 10", Description = "Samsung 10", Discount = 500 });
            productdiscounts.Add(new ProductDiscount() { Name = "Huawei Plus", Description = "Huawei Plus", Discount = 100 });
            productdiscounts.Add(new ProductDiscount() { Name = "Xiaomi Mi 9", Description = "Xiaomi Mi 9", Discount = 50 });
            productdiscounts.Add(new ProductDiscount() { Name = "HTC U11+ Plus", Description = "HTC U11+ Plus", Discount = 150 });
            productdiscounts.Add(new ProductDiscount() { Name = "LG G7 ThinQ", Description = "LG G7 ThinQ", Discount = 200 });
            return productdiscounts;
        }
    }
}
