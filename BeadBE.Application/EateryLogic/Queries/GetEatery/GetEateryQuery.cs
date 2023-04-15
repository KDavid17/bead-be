using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEatery
{
    public record GetEateryQuery(int Id) : IRequest<EateryResult>;
}
