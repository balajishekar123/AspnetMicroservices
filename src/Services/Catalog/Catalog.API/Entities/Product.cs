using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //BsonElement : Incase if we need to change the property name to mongo colleciton.
        [BsonElement("Name")]
        public string Name { set; get; }
        public string Category { set; get; }
        public string Summary { set; get; }
        public string Description { set; get; }
        public double Price { get; set; }
        public string ImageFile { get; set; }
    }
}
