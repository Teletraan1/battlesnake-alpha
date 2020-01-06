using Alpha.API.Constants;
using Alpha.API.Payloads.Requests;

namespace Alpha.API
{
    public interface ISnakeCharmer
    {
        public void AssessSituation(GameState state);
        public Direction MoveSnake();
    }
}
