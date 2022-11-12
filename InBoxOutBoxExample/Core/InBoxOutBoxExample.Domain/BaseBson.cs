using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Domain
{
    public class BaseBson
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("createddate")]
        public DateTime? CreatedDate { get; set; }

        [BsonElement("updateddate")]
        public DateTime? UpdatedDate { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }
    }
}
