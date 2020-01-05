using Alpha.API.Seedwork;

namespace Alpha.API.Constants
{
    public class CellContentType : Enumeration
    {
        public static readonly CellContentType Wall = new CellContentType(-1, @"wall");
        public static readonly CellContentType Empty = new CellContentType(0, @"empty");
        public static readonly CellContentType You = new CellContentType(1, @"you");
        public static readonly CellContentType Enemy = new CellContentType(2, @"enemy");
        public static readonly CellContentType Foot = new CellContentType(3, @"food");

        private CellContentType() { }
        private CellContentType(int value, string name) : base(value, name) { }
    }
}
