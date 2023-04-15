using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodLogic.Queries.GetFood
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, FoodResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodResult> Handle(GetFoodQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodRepository.FindByIdAsync(query.Id) is not Food food)
            {
                throw new BadHttpRequestException(
                    "Food with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new FoodResult(food);
        }
    }
}
