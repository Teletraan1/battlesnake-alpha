using Alpha.API.Seedwork;

namespace Alpha.API.Constants
{
    public class CellType : Enumeration
    {
        public static readonly CellType Wall = new CellType(-1, @"wall");
        public static readonly CellType Empty = new CellType(0, @"empty");
        public static readonly CellType You = new CellType(1, @"you");
        public static readonly CellType Enemy = new CellType(2, @"enemy");
        public static readonly CellType Foot = new CellType(3, @"food");

        private CellType() { }
        private CellType(int value, string name) : base(value, name) { }
    }
}
