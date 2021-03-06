﻿using Alpha.API.Payloads.Requests;
using Alpha.API.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Alpha.API.Controllers
{
    [ApiController]
    [Route("")]
    public class SnakeController : ControllerBase
    {
        private readonly ISnakeCharmer _snakeCharmer;

        public SnakeController(ISnakeCharmer snakeCharmer)
        {
            _snakeCharmer = snakeCharmer;
        }

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
            if (state == null) return BadRequest();

            //var gameId = state.Game.Id;
            var response = new Start();
            return Ok(response);
        }

        [HttpPost]
        [Route("Move")]
        public IActionResult Move(GameState state)
        {
            _snakeCharmer.AssessSituation(state);
            var direction = _snakeCharmer.MoveSnake();
            var move = new Move(direction);
            return Ok(move);
        }

        [HttpPost]
        [Route("End")]
        public IActionResult End(GameState request)
        {
            if (request == null) return Ok();

            var gameId = request.Game?.Id;
            Console.WriteLine($"Game {gameId} ended.");

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