using Alpha.API.Seedwork;

namespace Alpha.API.Models
{
    public class Snake
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Coordinate[] Body { get; set; }
        public Coordinate Head => Body[0];
        public Coordinate Tail => Body[^1];
    }
}
