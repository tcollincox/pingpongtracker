using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;

namespace testproj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private IMongoCollection<Player> _playerCollection;

        public PlayerController(IMongoClient client)
        {
            var database = client.GetDatabase("PingPongData");
            _playerCollection = database.GetCollection<Player>("playerData");
        }

        [HttpGet]
        [Route("player")]
        public IEnumerable<Player> Get()
        {
            return _playerCollection.Find(g => true).ToList();
        }

        [HttpPost]
        [Route("addPlayer")]
        public Player AddPlayer(Player player)
        {
            _playerCollection.InsertOne(player);
            return player;
        }
    }
}
