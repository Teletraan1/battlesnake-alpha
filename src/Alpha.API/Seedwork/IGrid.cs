using Alpha.API.Constants;
using System.Collections.Generic;

namespace Alpha.API.Seedwork
{
    public interface IGrid
    {
        CellType this[Coordinate coordinate] { get; set; }

        void Initialize(int height, int width);

        bool IsInitialized();

        void Clear();

        void SetCell(Coordinate coordinate, CellType cellType);
        void SetCells(Coordinate[] coordinates, CellType cellType);

        List<Coordinate> GetCoordinatesByType(CellType type);

        CellType LookAhead(Coordinate coordinate, Direction direction);
    }
}