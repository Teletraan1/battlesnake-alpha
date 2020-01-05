using Alpha.API.Constants;
using System.Text.Json.Serialization;

namespace Alpha.API.Payloads.Responses
{
    public class Move
    {
        [JsonPropertyName("move")]
        public string Direction { get; private set; } = @"up";

        public Move() { }

        public Move(Direction direction)
        {
            Direction = direction.DisplayName;
        }
    }
}
