using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Commands.PutEatery
{
    public record PutEateryCommand(
        int Id,
        int UserId,
        string Name,
        int Height,
        int Width) : IRequest<EateryResult>;
}
