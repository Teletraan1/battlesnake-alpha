using Alpha.API.Constants;
using System.Collections.Generic;

namespace Alpha.API.Seedwork
{
    public interface IGrid
    {
//#pragma warning disable CA1043 // Use Integral Or String Argument For Indexers
//        CellType this[Coordinate coordinate] { get; set; }
//#pragma warning restore CA1043 // Use Integral Or String Argument For Indexers

        void Initialize(int height, int width);

        bool IsInitialized();

        void Clear();

        void SetCell(Coordinate coordinate, CellType cellType);
        void SetCells(Coordinate[] coordinates, CellType cellType);

        CellType GetCell(Coordinate coordinate);
        List<Coordinate> GetCoordinatesByType(CellType type);

        CellType LookAhead(Coordinate coordinate, Direction direction);
    }
}