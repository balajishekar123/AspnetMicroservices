using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Discount.Grpc.Entities
{
    public class ProductDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //BsonElement : Incase if we need to change the property name to mongo colleciton.
        [BsonElement("Name")]
        public string Name { set; get; }       
        public string Description { set; get; }
        public double Discount { get; set; }
      
    }
}
