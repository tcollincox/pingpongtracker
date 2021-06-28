using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testproj
{
    [BsonIgnoreExtraElements]
    public class Player
    {
        
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("userName")]
        public string Username { get; set; }
        [BsonElement("color")]
        public string Color { get; set; }
    
    }
}
