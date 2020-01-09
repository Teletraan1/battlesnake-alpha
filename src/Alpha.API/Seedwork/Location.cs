namespace Alpha.API.Seedwork
{
    public class Location
    {
        public Coordinate Coordinate { get; set; }
        public Location Parent { get; set; }
        public int G { get; set; } = 0;
        public int H { get; set; } = 0;
        public int F => G + H;
    }
}
