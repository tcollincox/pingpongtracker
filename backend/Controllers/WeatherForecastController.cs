using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson ;

namespace testproj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMongoCollection<GameData> _gameDataCollection;
        private IMongoCollection<Player> _playerCollection;
        public WeatherForecastController(IMongoClient client)
        {
            var database = client.GetDatabase("PingPongData");
            _gameDataCollection = database.GetCollection<GameData>("gameData");
            _playerCollection = database.GetCollection<Player>("player");
        }

        [HttpGet]
        [Route("games")]
        public IEnumerable<GameData> Get()
        {
            return _gameDataCollection.Find(g =>true).ToList();
        }

        [HttpPost]
        [Route("addGame")]
        public GameData AddGame(GameData game)
        {
            _gameDataCollection.InsertOne(game);
            return game;
        }
        
    }
}
