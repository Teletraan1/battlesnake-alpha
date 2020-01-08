using Alpha.API.Constants;
using System;

namespace Alpha.API.Seedwork
{
    public static class CoordinateExtensions
    {
        public static Coordinate ApplyDirection(this Coordinate coordinate, Direction direction)
        {
            if (coordinate == null) coordinate = new Coordinate();
            if (direction == null) return coordinate;

            var x = coordinate.X + direction.Offset.X;
            var y = coordinate.Y + direction.Offset.Y;
            return new Coordinate(x, y);
        }

        public static double DistanceTo(this Coordinate coordinate, Coordinate destination)
        {
            if (coordinate == null) return double.NaN;
            if (destination == null) return double.NaN;

            var xFactor = (coordinate.X - destination.X) * (coordinate.X - destination.X);
            var yFactor = (coordinate.Y - destination.Y) * (coordinate.Y - destination.Y);

            return Math.Sqrt(xFactor + yFactor);
        }
    }
}