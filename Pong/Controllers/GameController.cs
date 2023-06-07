using Microsoft.AspNetCore.Mvc;
using Pong.Contexts;
using Pong.Models;

namespace Pong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly PongContext _context;

        public GameController(PongContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _context.Games.Select(row => row).ToArray();
        }
    }
}