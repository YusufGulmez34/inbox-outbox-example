using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InBoxOutBoxExample.Domain.Read.Entities
{
    public class Product : BaseBson
    {
        
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("brand")]
        public string Brand { get; set; }
        
        [BsonElement("category")]
        public string Category { get; set; }
        
        [BsonElement("description")]
        public string? Description { get; set; }
        
        [BsonElement("price")]
        public int Price { get; set; }
    }
}
