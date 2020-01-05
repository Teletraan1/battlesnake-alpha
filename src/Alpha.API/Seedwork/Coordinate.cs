namespace Alpha.API.Seedwork
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate() { }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
