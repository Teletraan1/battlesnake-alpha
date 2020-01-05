using Alpha.API.Models;

namespace Alpha.API.Payloads.Requests
{
    public class GameState
    {
        public Game Game { get; set; }
        public int Turn { get; set; }
        public Board Board { get; set; }
        public Snake You { get; set; }
    }
}
