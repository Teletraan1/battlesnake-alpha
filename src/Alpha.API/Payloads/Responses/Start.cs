using Alpha.API.Constants;

namespace Alpha.API.Payloads.Responses
{
    public class Start
    {
        public string Color { get; private set; } = "#F28500";
        public string HeadType { get; private set; } = HeadTypes.Pixel;
        public string TailType { get; private set; } = TailTypes.Pixel;

        public Start() { }

        public Start(string color, string headType, string tailType)
        {
            Color = color;
            HeadType = headType;
            TailType = tailType;
        }
    }
}
