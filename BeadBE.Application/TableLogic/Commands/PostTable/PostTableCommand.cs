using BeadBE.Application.TableLogic.Common;
using MediatR;

namespace BeadBE.Application.TableLogic.Commands.PostTable
{
    public record PostTableCommand(int Seats) : IRequest<TableResult>;
}
