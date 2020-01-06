using Alpha.API.Constants;
using Alpha.API.Models;
using Alpha.API.Payloads.Requests;
using Alpha.API.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.API
{
    public class SnakeCharmer : ISnakeCharmer
    {
        private const int FOOD_DISTANCE = 5;

        private readonly IRandomizer _randomizer;

        private Board _board;
        private Snake _you;
        private int _turn;
        private List<Snake> _snakes = new List<Snake>();

        private int _lowHealthThreshold;

        public SnakeCharmer(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public void AssessSituation(GameState state)
        {
            _board = state.Board;
            _you = state.You;
            _turn = state.Turn;
            _snakes = state.Board.Snakes.ToList();

            _lowHealthThreshold = CalculateHealthTheshold();
        }

        public Direction MoveSnake()
        {
            var options = Direction.All;

            Console.WriteLine("Turn {0}", _turn);

            BasicAvoidance(options);

            if (options.Length == 1) 
                return options.First();
            
            if (options.Length > 1)
            {
                //Go thorugh priority list
                if (IsLowHealth(_you.Health))
                {
                    //find closest food
                    Console.WriteLine("Health is low at {0}", _you.Health);
                }

                var index = _randomizer.Roll(0, options.Length - 1);
                return options[index];
            }

            return Direction.Right;
        }
                
        private void BasicAvoidance(IList<Direction> options)
        {
            foreach (var direction in Direction.All)
            {
                var choice = _you.Head.ApplyDirection(direction);

                if (IsWall(choice) || IsBody(choice))
                {
                    options.Remove(direction);
                    continue;
                }

                Console.WriteLine("Viable Direction {0}", choice);
            }
        }

        //Avoid going out of bounds.
        private bool IsWall(Coordinate coordinate)
        {
            if (coordinate.Y == -1 || coordinate.Y == _board.Height)
                return true;

            if (coordinate.X == -1 || coordinate.X == _board.Width)
                return true;

            return false;
        }

        //Any snake's bodypart except for heads.
        private bool IsBody(Coordinate coordinate)
        {
            foreach (var snake in _snakes)
            {
                var body = snake.Body.Skip(1);
                if (body.Where(piece => coordinate.Equals(piece)).Count() > 0)
                    return true;
            }

            return false;
        }

        private bool IsLowHealth(int health)
        {
            var effectiveHealth = health - FOOD_DISTANCE;
            return effectiveHealth < Snake.MaxHealth - _lowHealthThreshold;
        }

        private int CalculateHealthTheshold()
        {
            var numerator = Math.Abs(_turn - _you.Health);
            var denominator = _turn + _you.Health;
            var ratio = decimal.Divide(numerator, denominator) * Snake.MaxHealth;
           return (int)(Snake.MaxHealth - Math.Round(ratio));
        }
    }
}
