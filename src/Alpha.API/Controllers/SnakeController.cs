using Alpha.API.Payloads.Requests;
using Alpha.API.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.API.Controllers
{
    [ApiController]
    [Route("")]
    public class SnakeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new Start();
            return Ok(response);
        }

        [HttpPost]
        [Route("Start")]
        public IActionResult Start(GameState state)
        {
            var gameId = state.Game.Id;
            var response = new Start();
            return Ok(response);
        }

        [HttpPost]
        [Route("Move")]
        public IActionResult Move(GameState state)
        {
            var charmer = new SnakeCharmer(state);
            var direction = charmer.MoveSnake();
            return Ok(direction.DisplayName);
        }

        [HttpPost]
        [Route("End")]
        public IActionResult End(GameState request)
        {
            return Ok();
        }

        [HttpPost]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}