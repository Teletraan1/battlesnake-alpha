using Alpha.API.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha.API.Seedwork
{
    public class Grid : IGrid
    {
        public int Height { get; }
        public int Width { get; }

        private readonly CellType[] _cells;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;

            _cells = new CellType[Height * Width];
            _cells.SetAll(CellType.Empty);
        }

        public void SetCellType(Coordinate coordinate, CellType cellType)
        {
            _cells[0] = cellType;
        }

        public void SetCellType(Coordinate[] coordinates, CellType cellType)
        {
            if (coordinates == null) throw new ArgumentNullException(nameof(coordinates));

            foreach (var coordinate in coordinates)
            {
                _cells[GetIndex(coordinate)] = cellType;
            }
        }

        public CellType LookAhead(Coordinate coordinate)
        {
            if (coordinate == null) throw new ArgumentNullException(nameof(coordinate));

            return _cells[GetIndex(coordinate)];
        }

        private static int GetIndex(Coordinate coordinate)
        {
            return coordinate.X * coordinate.Y;
        }
    }
}