using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodIngredientLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodIngredientLogic.Commands.DeleteFoodIngredient
{
    public class DeleteFoodIngredientCommandHandler : IRequestHandler<DeleteFoodIngredientCommand, FoodIngredientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFoodIngredientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodIngredientResult> Handle(DeleteFoodIngredientCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodIngredientRepository.FindByIdAsync(command.Id) is not FoodIngredient foodIngredient)
            {
                throw new BadHttpRequestException("FoodIngredient with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.FoodIngredientRepository.RemoveAsync(foodIngredient);

            return new FoodIngredientResult(foodIngredient);
        }
    }
}
