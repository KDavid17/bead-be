using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodDetails
{
    public class GetFoodDetailsByIdQueryHandler : IRequestHandler<GetFoodDetailsByIdQuery, FoodDetailsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodDetailsByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodDetailsResult> Handle(GetFoodDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodRepository.FindFoodWithDetailsByIdAsync(query.Id) is not FoodDetails foodDetails)
            {
                throw new BadHttpRequestException(
                    "Food with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new FoodDetailsResult(foodDetails);
        }
    }
}
