using Alpha.API.Seedwork;
using System;
using System.Collections.Generic;

namespace Alpha.API.Constants
{
    public class CellType : Enumeration
    {
        public static readonly CellType Wall = new CellType(0, @"wall", int.MaxValue);
        public static readonly CellType You = new CellType(1, @"you", int.MaxValue);
        public static readonly CellType YourTail = new CellType(2, @"your-tail", 2);
        public static readonly CellType Food = new CellType(3, @"food", 1);
        public static readonly CellType Empty = new CellType(4, @"empty", 2);        
        public static readonly CellType Enemy = new CellType(5, @"enemy", int.MaxValue);
        public static readonly CellType EnemyHead = new CellType(6, @"enemy-head", 3);

        public static readonly List<CellType> NonTraversable = new List<CellType> { Wall, You, Enemy };

        public int Difficulty { get; private set; } = 1;

        private CellType()
        {
        }

        private CellType(Index index, string name) : base(index, name)
        {
        }

        private CellType(Index index, string name, int difficulty) : base(index, name)
        {
            Difficulty = difficulty;
        }

        public void ChangeDifficulty(int value)
        {
            Difficulty = value;
        }
    }
}