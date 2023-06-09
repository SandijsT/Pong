﻿using Microsoft.AspNetCore.Mvc;
using Pong.Contexts;
using Pong.Models;

namespace Pong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PongContext _context;

        public PlayerController(PongContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _context.Players.Select(row => row).ToArray();
        }

        [HttpPost]
        public async Task<bool> Post(Player player)
        {
            player.Score = 0;
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
