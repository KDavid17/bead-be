using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateriesByParam
{
    public class GetEateriesByParamQueryHandler : IRequestHandler<GetEateriesByParamQuery, EateriesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEateriesByParamQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateriesResult> Handle(GetEateriesByParamQuery query, CancellationToken cancellationToken)
        {
            return new EateriesResult(await _unitOfWork.EateryRepository.FindEateriesByParamAsync(query.SearchParam));
        }
    }
}
