using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Commands.DeleteEatery
{
    public record DeleteEateryCommand(int Id) : IRequest<EateryResult>;
}
