using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Application.EateryLogic.Queries.GetEatery;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEaterys
{
    public class GetEaterysQueryHandler : IRequestHandler<GetEateriesQuery, EateriesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEaterysQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateriesResult> Handle(GetEateriesQuery query, CancellationToken cancellationToken)
        {
            return new EateriesResult(await _unitOfWork.EateryRepository.FindAllAsync());
        }
    }
}
