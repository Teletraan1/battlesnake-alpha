using Alpha.API.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha.API.Seedwork
{
    public class Grid
    {
        public int Height { get; }
        public int Width { get; }
        private readonly CellType[] Cells;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;

            Cells = new CellType[Height * Width];
            Cells.SetAll(CellType.Empty);
        }

        public void SetCellType(Coordinate coordinate, CellType cellType)
        {
            Cells[0] = cellType;
        }
    }
}
