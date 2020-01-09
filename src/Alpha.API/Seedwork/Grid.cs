using Alpha.API.Constants;
using System;
using System.Collections.Generic;

namespace Alpha.API.Seedwork
{
    public class Grid : IGrid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool Initialized { get; private set; } = false;

        private CellType[,] _cells;

        public Grid()
        {
        }

        public CellType this[Coordinate coordinate]
        {
            get
            {
                try
                {
                    return _cells[coordinate.Y, coordinate.X];
                }
                catch (IndexOutOfRangeException)
                {
                    return CellType.Wall;
                }
            }
            set
            {
                _cells[coordinate.Y, coordinate.X] = value;
            }
        }

        public bool IsInitialized() => Initialized;
        
        public void Initialize(int height, int width)
        {
            Height = height;
            Width = width;

            _cells = new CellType[Height, Width];
            _cells.SetAll(CellType.Empty);

            Initialized = true;
        }
        
        public List<Coordinate> GetCoordinatesByType(CellType type)
        {
            var collection = new List<Coordinate>();

            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    if (_cells[y, x] == type) collection.Add(new Coordinate(x, y));
                }
            }

            return collection;
        }

        public void SetCell(Coordinate coordinate, CellType cellType)
        {
            this[coordinate] = cellType;
        }

        public void SetCells(Coordinate[] coordinates, CellType cellType)
        {
            if (coordinates == null) return;

            for (var i = 0; i < coordinates.Length; i++)
            {
                this[coordinates[i]] = cellType;
            }
        }

        public void Clear()
        {
            _cells.SetAll(CellType.Empty);
        }

        public CellType LookAhead(Coordinate coordinate, Direction direction)
        {
            var adjacent = coordinate.ApplyDirection(direction);

            try
            {
                return this[adjacent];
            }
            catch (IndexOutOfRangeException)
            {
                return CellType.Wall;
            }
        }
    }
}