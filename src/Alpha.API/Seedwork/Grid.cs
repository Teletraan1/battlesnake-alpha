using Alpha.API.Constants;
using System;

namespace Alpha.API.Seedwork
{
    public class Grid : IGrid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool Initialized { get; private set; } = false;

        private CellType[][] _cells;

        public Grid()
        {
        }

        public void Initialize(int height, int width)
        {
            Height = height;
            Width = width;

            _cells = new CellType[Height][];
            var columns = new CellType[Width];
            columns.SetAll(CellType.Empty);
            _cells.SetAll(columns);

            Initialized = true;
        }

        public bool IsInitialized() => Initialized;

#pragma warning disable CA1043 // Use Integral Or String Argument For Indexers

        public CellType this[Coordinate coordinate]
        {
            get
            {
                try
                {
                    return coordinate != null ? _cells[coordinate.Y][coordinate.X] : CellType.Wall;
                }
                catch (IndexOutOfRangeException)
                {
                    return CellType.Wall;
                }
            }
            set
            {
                if (coordinate != null) _cells[coordinate.Y][coordinate.X] = value;
            }
        }

#pragma warning restore CA1043 // Use Integral Or String Argument For Indexers

        public void SetCellType(Coordinate[] coordinates, CellType cellType)
        {
            if (coordinates == null) return;

            for (var i = 0; i < coordinates.Length; ++i)
            {
                this[coordinates[i]] = cellType;
            }
        }

        public CellType LookAhead(Coordinate coordinate, Direction direction)
        {
            if (coordinate == null) throw new ArgumentNullException(nameof(coordinate));

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

        public CellType LookAhead(Coordinate coordinate)
        {
            if (coordinate == null) throw new ArgumentNullException(nameof(coordinate));

            return this[coordinate];
        }
    }
}