using Alpha.API.Constants;
using Alpha.API.Models;
using Alpha.API.Payloads.Requests;

namespace Alpha.API
{
    public class SnakeCharmer
    {
        private readonly Board _board;

        public SnakeCharmer(GameState state)
        {
            _board = state.Board;
        }

        public Direction MoveSnake()
        {
            return Direction.Up;
        }

    }
}
