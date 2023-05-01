using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateriesByUserId
{
    public record GetEateriesByUserIdQuery(int Id) : IRequest<EateriesResult>;
}
