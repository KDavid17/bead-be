using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodLogic.Commands.DeleteFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, FoodResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodResult> Handle(DeleteFoodCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodRepository.FindByIdAsync(command.Id) is not Food food)
            {
                throw new BadHttpRequestException("Food with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.FoodRepository.RemoveAsync(food);

            return new FoodResult(food);
        }
    }
}
