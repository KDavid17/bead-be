using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodsDetailsByEateryId
{
    public class GetFoodsDetailsByEateryIdQueryHandler : IRequestHandler<GetFoodsDetailsByEateryIdQuery, FoodsDetailsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodsDetailsByEateryIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodsDetailsResult> Handle(GetFoodsDetailsByEateryIdQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EateryRepository.FindByIdAsync(query.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Eatery with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new FoodsDetailsResult(await _unitOfWork.FoodRepository.FindFoodsWithDetailsByEateryIdAsync(query.Id));
        }
    }
}
