using System;

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
    }
}
