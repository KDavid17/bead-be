using BeadBE.Application.TableLogic.Common;
using MediatR;

namespace BeadBE.Application.TableLogic.Commands.DeleteTable
{
    public record DeleteTableCommand(int Id) : IRequest<TableResult>;
}
