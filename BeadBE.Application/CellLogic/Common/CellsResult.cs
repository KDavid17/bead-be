using BeadBE.Domain.Entities;

namespace BeadBE.Application.CellLogic.Common
{
    public record CellsResult(IEnumerable<Cell> Cells);
}
