using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodIngredientLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PutFoodIngredient
{
    public class PutFoodIngredientCommandHandler : IRequestHandler<PutFoodIngredientCommand, FoodIngredientResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutFoodIngredientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodIngredientResult> Handle(PutFoodIngredientCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodIngredientRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "FoodIngredient with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var foodIngredient = _mapper.Map<FoodIngredient>(command);

            await _unitOfWork.FoodIngredientRepository.UpdateAsync(foodIngredient);

            return new FoodIngredientResult(foodIngredient);
        }
    }
}
