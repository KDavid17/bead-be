using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.FoodLogic.Commands.PostFood
{
    public class PostFoodCommandHandler : IRequestHandler<PostFoodCommand, FoodResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostFoodCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodResult> Handle(PostFoodCommand command, CancellationToken cancellationToken)
        {
            var food = _mapper.Map<Food>(command);

            if (command.Ingredients is not null)
            {
                var ingredients = command.Ingredients;

                await _unitOfWork.FoodRepository.AddFoodWithIngredientsAsync(food, ingredients);
            }
            else
            {
                await _unitOfWork.FoodRepository.AddAsync(food);
            }

            return new FoodResult(food);
        }
    }
}
