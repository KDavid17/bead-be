using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEatery
{
    public record GetEateriesQuery() : IRequest<EateriesResult>;
}
