using Alpha.API.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alpha.API.Seedwork
{
    public static class Algorithms
    {
        public static double Euclidean(Coordinate start, Coordinate end)
        {
            var xDelta = start.X - end.X;
            var yDelta = start.Y - end.Y;

            var xFactor = xDelta * xDelta;
            var yFactor = yDelta * yDelta;

            return Math.Sqrt(xFactor + yFactor);
        }

        public static int Manhattan(Coordinate start, Coordinate end)
        {
            var xDelta = start.X - end.X;
            var yDelta = start.Y - end.Y;

            var xFactor = Math.Abs(xDelta);
            var yFactor = Math.Abs(yDelta);

            return xFactor + yFactor;
        }

        public static Coordinate AStar(Grid grid, Coordinate start, Coordinate target)
        {
            if (grid == null) throw new ArgumentNullException(nameof(grid));

            if (start == target)
                return start;

            var priorityLocations = new PriorityQueue<Location>();
            var visitedLocations = new List<Location>();
            var current = new Location(start);
            var gScore = 0;

            priorityLocations.Enqueue(current);

            while (priorityLocations.Count > 0)
            {
                current = priorityLocations.Dequeue();
                
                if (current.Coordinate == target)
                    break;

                visitedLocations.Add(current);

                var adjacentLocations = grid.LookAhead(current.Coordinate).Where(l => !CellType.NonTraversable.Any(x => x == l.CellType));

                //if (adjacentLocations.Any(x => x.Coordinate == target))
                //{
                //    var goal = adjacentLocations.Where(x => x.Coordinate == target).FirstOrDefault();
                //    var heuristic = Manhattan(goal.Coordinate, target);
                //    goal.ComputeScore(gScore, heuristic, current);
                //    priorityLocations.Enqueue(goal);
                //    break;
                //}

                //adjacentLocations = adjacentLocations.Where(l => !CellType.NonTraversable.Any(x => x == l.CellType));

                gScore++;
                foreach (var adjacentLocation in adjacentLocations)
                {
                    if (visitedLocations.FirstOrDefault(l => l.Coordinate == adjacentLocation.Coordinate) != null)
                        continue;

                    var heuristic = Manhattan(adjacentLocation.Coordinate, target);
                    adjacentLocation.ComputeScore(gScore, heuristic, current);
                    priorityLocations.Enqueue(adjacentLocation);
                }
            }
            
            while (current.Parent != null && current.Parent.Coordinate != start)
            {
                current = current.Parent;
            }

            return current.Coordinate;
        }
    }
}
