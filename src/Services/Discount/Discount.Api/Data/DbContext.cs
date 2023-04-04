using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Data
{
    public class DbContext : IDbContext
    {
        private MongoClient _client { set; get; }
        
        public DbContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));                      
            var database = _client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            productDiscounts = database.GetCollection<ProductDiscount>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogSeedData.SeedData(productDiscounts);

        }
       

        public IMongoCollection<ProductDiscount> productDiscounts { get; }
    }
}
