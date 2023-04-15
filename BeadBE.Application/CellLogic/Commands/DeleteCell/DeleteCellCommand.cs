using BeadBE.Application.CellLogic.Common;
using MediatR;

namespace BeadBE.Application.CellLogic.Commands.DeleteCell
{
    public record DeleteCellCommand(int Id) : IRequest<CellResult>;
}
