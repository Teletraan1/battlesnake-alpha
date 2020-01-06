using Alpha.API.Constants;

namespace Alpha.API.Seedwork
{
    public static class CoordinateExtensions
    {
        public static Coordinate ApplyDirection(this Coordinate coordinate, Direction direction)
        {
            var x = coordinate.X + direction.Offset.X;
            var y = coordinate.Y + direction.Offset.Y;
            return new Coordinate(x, y);
        }
    }
}
