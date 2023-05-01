using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateriesByParam
{
    public record GetEateriesByParamQuery(string SearchParam) : IRequest<EateriesResult>;
}