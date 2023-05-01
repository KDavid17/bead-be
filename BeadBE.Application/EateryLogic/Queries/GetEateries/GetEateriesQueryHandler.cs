using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateries
{
    public class GetEateriesQueryHandler : IRequestHandler<GetEateriesQuery, EateriesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEateriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateriesResult> Handle(GetEateriesQuery query, CancellationToken cancellationToken)
        {
            return new EateriesResult(await _unitOfWork.EateryRepository.FindAllAsync());
        }
    }
}
