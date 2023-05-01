using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using MediatR;

namespace BeadBE.Application.EateryLogic.Queries.GetEateriesByUserId
{
    public class GetEateriesByUserIdQueryHandler : IRequestHandler<GetEateriesByUserIdQuery, EateriesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEateriesByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateriesResult> Handle(GetEateriesByUserIdQuery query, CancellationToken cancellationToken)
        {
            return new EateriesResult(await _unitOfWork.EateryRepository.FindAsync(e => e.UserId == query.Id));
        }
    }
}
