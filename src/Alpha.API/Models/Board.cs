using Alpha.API.Seedwork;
using System.Collections.Generic;

namespace Alpha.API.Models
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Coordinate[] Food { get; set; }
        public IEnumerable<Snake> Snakes { get; set; }
        public IEnumerable<Coordinate> Walls { get; set; }
    }
}
