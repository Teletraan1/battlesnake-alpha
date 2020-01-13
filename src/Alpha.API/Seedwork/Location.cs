using Alpha.API.Constants;
using System;

namespace Alpha.API.Seedwork
{
    public class Location : ValueObject, IComparable<Location>
    {
        public Location Parent { get; set; } = null;
        public Coordinate Coordinate { get; set; }
        public CellType CellType { get; set; }

        [IgnoreMember]
        public double G { get; set; } = 0;
        [IgnoreMember]
        public double H { get; set; } = 0;
        [IgnoreMember]
        public double F => G + H;

        public Location() { }

        public Location(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void ComputeScore(double g, double h, Location parent)
        {
            G = g;
            H = h;
            Parent = parent;
        }

        public static bool operator <(Location left, Location right)
        {
            return left is null ? right is object : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Location left, Location right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Location left, Location right)
        {
            return left is object && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Location left, Location right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }

        public int CompareTo(Location location)
        {
            return Compare(location);
        }

        public int CompareTo(object location)
        {
            var otherLocation = location as Location;
            return Compare(otherLocation);            
        }

        private int Compare(Location otherLocation)
        {
            if (otherLocation is null)
                return 1;

            if (F < otherLocation.F)
                return -1;

            if (F == otherLocation.F)
                return 0;

            return 1;
        }
    }
}
