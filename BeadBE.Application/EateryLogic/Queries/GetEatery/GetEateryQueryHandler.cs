using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.EateryLogic.Queries.GetEatery
{
    public class GetEateryQueryHandler : IRequestHandler<GetEateryQuery, EateryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEateryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateryResult> Handle(GetEateryQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EateryRepository.FindByIdAsync(query.Id) is not Eatery eatery)
            {
                throw new BadHttpRequestException(
                    "Eatery with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new EateryResult(eatery);
        }
    }
}
