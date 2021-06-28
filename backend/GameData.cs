using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testproj
{
    [BsonIgnoreExtraElements]
    public class GameData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("winner")]
        public Player Winner { get; set; }
        [BsonElement("loser")]
        public Player Loser { get; set; }
        [BsonElement("winnerScore")]
        public int WinnerScore { get; set; }
        [BsonElement("loserScore")]
        public int LoserScore { get; set; }
    }
}
