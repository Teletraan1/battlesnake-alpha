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
        private readonly IRandomizer _randomizer;
        private readonly IGrid _grid;

        private Board _board;
        private Snake _you;
        private int _turn;
        private Snake[] _snakes;
        private Snake[] _enemySnakes;

        public SnakeCharmer(IRandomizer randomizer, IGrid grid)
        {
            _randomizer = randomizer;
            _grid = grid;
        }

        public void AssessSituation(GameState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            _turn = state.Turn;
            _board = state.Board;
            _snakes = state.Board.Snakes.ToArray();
            _you = state.You;
            _enemySnakes = state.Board.Snakes.Where(snake => snake.Id != _you.Id).ToArray();

            if (!_grid.IsInitialized()) _grid.Initialize(_board.Height, _board.Width);

            UpdateGrid(_board.Food, _you, _enemySnakes);


            Console.WriteLine();
            Console.WriteLine($"Turn {_turn}");
            Console.WriteLine($"GameState You coords: {string.Join(',', state.You.Body)}");
            Console.WriteLine($"Head at {_you.Head}");
        }

        public Direction MoveSnake()
        {
            Coordinate coordinate;

            coordinate = Algorithms.AStar(_grid as Grid, _you.Head, GetClosestFood(out var distance));

            //if (IsLowHealth(_you.Health, out var foodLocation) || _you.Head == _you.Tail)
            //    coordinate = Algorithms.AStar(_grid as Grid, _you.Head, foodLocation);
            //else
            //    coordinate = Algorithms.AStar(_grid as Grid, _you.Head, _you.Tail);

            var choice = Direction.All.ToList()
                                      .Where(x => _you.Head.ApplyDirection(x) == coordinate)
                                      .FirstOrDefault();            

            Console.WriteLine($"Choice is {choice}");
            Console.WriteLine();

            return choice ?? Direction.Up;
        }       

        private bool IsLowHealth(int health, out Coordinate food)
        {
            food = GetClosestFood(out var distance);
            var effectiveHealth = health - (distance + 1);
            var allowableHealth = Snake.MaxHealth - CalculateHealthThreshold();
            return effectiveHealth < allowableHealth;
        }

        private Coordinate GetClosestFood(out double distance)
        {
            var foodCollection = _board.Food;
            var closestFood = foodCollection[0];

            distance = _you.Head.DistanceTo(foodCollection[0]);
            
            for (var i = 1; i < foodCollection.Length; i++)
            {
                var newDistance = _you.Head.DistanceTo(foodCollection[i]);

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestFood = foodCollection[i];
                }
            }

            Console.WriteLine($"Closest food distance of {distance} at {closestFood}");
            return closestFood;
        }

        private int CalculateHealthThreshold()
        {
            var numerator = Math.Abs(_turn - _you.Health);
            var denominator = _turn + _you.Health;
            var ratio = decimal.Divide(numerator, denominator) * Snake.MaxHealth;
            return (int)(Snake.MaxHealth - Math.Round(ratio));
        }

        private bool IsBiggest()
        {
            var biggestSnake = _you.Id;
            int length = _you.Body.Length;
            for (var i = 0; i < _enemySnakes.Length; i++)
            {
                var current = _enemySnakes[i];
                if (current.Body.Length > length)
                {
                    biggestSnake = current.Id;
                }
            }

            return _you.Id.Equals(biggestSnake, StringComparison.InvariantCultureIgnoreCase);
        }

        private void UpdateGrid(Coordinate[] food, Snake you, IEnumerable<Snake> enemySnakes)
        {
            _grid.Clear();
            _grid.SetCells(food, CellType.Food);
            _grid.SetCells(you.Body, CellType.You);

            foreach (var snake in enemySnakes)
            {
                _grid[snake.Head] = CellType.EnemyHead;
                var body = snake.Body.Skip(1).ToArray();
                _grid.SetCells(body, CellType.Enemy);
            }
        }

        //private void BasicAvoidance(ICollection<Direction> options)
        //{

        //    var head = _you.Head;
        //    foreach (var direction in Direction.All)
        //    {
        //        var cell = _grid.LookAhead(head, direction);
        //        var coord = head.ApplyDirection(direction);

        //        Console.WriteLine($"{direction} is {cell} {coord}");

        //        if (cell == CellType.Enemy || cell == CellType.You || cell == CellType.Wall)
        //        {
        //            options.Remove(direction);
        //            continue;
        //        }

        //        Console.WriteLine($"Viable Direction {direction} to {cell}");
        //    }
        //}

        ////Any snake's body-part except for heads.
        //private bool IsBody(Coordinate coordinate, Direction direction)
        //{
        //    var cellType = _grid.LookAhead(coordinate, direction);
        //    var result = cellType == CellType.Enemy || cellType == CellType.You;
        //    return result;
        //}
    }
}