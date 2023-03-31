using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class DbContext : IDbContext
    {
        private MongoClient _client { set; get; }
        
        public DbContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));                      
            var database = _client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogSeedData.SeedData(products);

        }
        public IMongoCollection<Product> products { get; }
        
    }
}
