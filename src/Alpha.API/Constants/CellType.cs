using Alpha.API.Seedwork;
using System.Collections.Generic;

namespace Alpha.API.Constants
{
    public class CellType : Enumeration
    {
        public static readonly CellType Wall = new CellType(-1, @"wall", int.MaxValue);
        public static readonly CellType You = new CellType(0, @"you", int.MaxValue);
        public static readonly CellType Enemy = new CellType(3, @"enemy", int.MaxValue);
        public static readonly CellType EnemyHead = new CellType(4, "enemy-head", 3);
        public static readonly CellType Empty = new CellType(1, @"empty", 2);
        public static readonly CellType Food = new CellType(2, @"food", 1);

        public static readonly List<CellType> NonTraversable = new List<CellType> { Wall, You, Enemy };

        public int Difficulty { get; private set; } = 1;

        private CellType()
        {
        }

        private CellType(int value, string name) : base(value, name)
        {
        }

        private CellType(int value, string name, int difficulty) : base(value, name)
        {
            Difficulty = difficulty;
        }

        public void ChangeDifficulty(int value)
        {
            Difficulty = value;
        }
    }
}