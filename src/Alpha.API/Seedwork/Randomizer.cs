using System;
namespace Alpha.API.Seedwork
{
    public class Randomizer : IRandomizer
    {
        private static readonly Random _random = new Random();

        public int Roll(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
