using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodIngredientLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodIngredientLogic.Commands.PostFoodIngredient
{
    public class PostFoodIngredientCommandHandler : IRequestHandler<PostFoodIngredientCommand, FoodIngredientResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostFoodIngredientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodIngredientResult> Handle(PostFoodIngredientCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodIngredientRepository.FindAsync(fi => fi.FoodId == command.FoodId && fi.IngredientId == command.IngredientId) is not null)
            {
                throw new BadHttpRequestException(
                    "Ingredient is already in the list of ingredients for this food!",
                    StatusCodes.Status400BadRequest);
            }

            var foodIngredient = _mapper.Map<FoodIngredient>(command);

            await _unitOfWork.FoodIngredientRepository.AddAsync(foodIngredient);

            return new FoodIngredientResult(foodIngredient);
        }
    }
}
