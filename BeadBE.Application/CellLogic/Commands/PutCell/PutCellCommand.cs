using BeadBE.Application.CellLogic.Common;
using MediatR;

namespace BeadBE.Application.CellLogic.Commands.PutCell
{
    public record PutCellCommand(
        int Id,
        string Name,
        bool IsAllergen) : IRequest<CellResult>;
}
