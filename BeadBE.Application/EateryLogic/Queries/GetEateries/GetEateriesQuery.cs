using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateries
{
    public record GetEateriesQuery() : IRequest<EateriesResult>;
}
