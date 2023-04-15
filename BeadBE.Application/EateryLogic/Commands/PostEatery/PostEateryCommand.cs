using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Commands.PostEatery
{
    public record PostEateryCommand(
        int UserId,
        string Name,
        int Height,
        int Width) : IRequest<EateryResult>;
}
