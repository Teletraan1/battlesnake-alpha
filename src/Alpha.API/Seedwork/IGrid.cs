using Alpha.API.Constants;

namespace Alpha.API.Seedwork
{
    public interface IGrid
    {
#pragma warning disable CA1043 // Use Integral Or String Argument For Indexers
        CellType this[Coordinate coordinate] { get; set; }
#pragma warning restore CA1043 // Use Integral Or String Argument For Indexers

        void Initialize(int height, int width);

        bool IsInitialized();

        void SetCellType(Coordinate[] coordinates, CellType cellType);

        CellType LookAhead(Coordinate coordinate);
    }
}