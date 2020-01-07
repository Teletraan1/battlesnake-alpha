using Alpha.API.Constants;

namespace Alpha.API.Seedwork
{
    public interface IGrid
    {
        void SetCellType(Coordinate coordinate, CellType cellType);

        void SetCellType(Coordinate[] coordinates, CellType cellType);

        CellType LookAhead(Coordinate coordinate);
    }
}