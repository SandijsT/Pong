using Microsoft.AspNetCore.Mvc;
using Pong.Models;

namespace Pong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Game
            {
                Date = DateTime.Now.AddDays(index),
                Challanger = Random.Shared.Next(-20, 55),
                Opponent = Random.Shared.Next(-20, 55),
                Winner = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }
    }
}