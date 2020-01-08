using System.Text.Json.Serialization;
using Alpha.API.Seedwork;

namespace Alpha.API.Payloads.Responses
{
    public class Move
    {
        [JsonPropertyName("move")]
        public string Direction { get; private set; } = @"up";

        public Move()
        {
        }

        public Move(Enumeration direction)
        {
            if (direction != null) Direction = direction.DisplayName;
        }
    }
}