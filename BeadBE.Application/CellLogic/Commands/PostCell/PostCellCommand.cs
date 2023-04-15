using BeadBE.Application.CellLogic.Common;
using MediatR;

namespace BeadBE.Application.CellLogic.Commands.PostCell
{
    public record PostCellCommand(
        string Name,
        bool IsAllergen) : IRequest<CellResult>;
}
