using BeadBE.Application.CellLogic.Common;
using MediatR;

namespace BeadBE.Application.CellLogic.Queries.GetCell
{
    public record GetCellQuery(int Id) : IRequest<CellResult>;
}
