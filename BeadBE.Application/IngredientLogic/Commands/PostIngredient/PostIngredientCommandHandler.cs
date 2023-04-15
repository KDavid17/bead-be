using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Commands.PostIngredient
{
    public class PostIngredientCommandHandler : IRequestHandler<PostIngredientCommand, IngredientResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostIngredientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientResult> Handle(PostIngredientCommand command, CancellationToken cancellationToken)
        {
            var ingredient = _mapper.Map<Ingredient>(command);

            await _unitOfWork.IngredientRepository.AddAsync(ingredient);

            return new IngredientResult(ingredient);
        }
    }
}
