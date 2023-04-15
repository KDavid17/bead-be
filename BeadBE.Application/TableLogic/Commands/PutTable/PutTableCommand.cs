using BeadBE.Application.TableLogic.Common;
using MediatR;

namespace BeadBE.Application.TableLogic.Commands.PutTable
{
    public record PutTableCommand(
        int Id,
        int Seats) : IRequest<TableResult>;
}
