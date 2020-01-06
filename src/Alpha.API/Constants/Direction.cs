using Alpha.API.Seedwork;
using System.Linq;

namespace Alpha.API.Constants
{
    public class Direction : Enumeration
    {
        public static readonly Direction Up = new Direction(0, @"up");
        public static readonly Direction Down = new Direction(1, @"down");
        public static readonly Direction Left = new Direction(2, @"left");
        public static readonly Direction Right = new Direction(3, @"right");

        public static readonly Direction[] All = GetAll<Direction>().ToArray();

        public Coordinate Slither { get; private set; }

        public Direction() { }

        private Direction(int value, string name) : base(value, name) 
        {
            Slither = value switch
            {
                0 => new Coordinate(0, -1),
                1 => new Coordinate(0, 1),
                2 => new Coordinate(-1, 0),
                _ => new Coordinate(1, 0),
            };
        }
    }
}
