using Alpha.API.Seedwork;
using System.Collections.Generic;

namespace Alpha.API.Models
{
    public class Board
    {
        //Y
        public int Height { get; set; }

        //X
        public int Width { get; set; }

        public Coordinate[] Food { get; set; }

        public IEnumerable<Snake> Snakes { get; set; }
    }
}