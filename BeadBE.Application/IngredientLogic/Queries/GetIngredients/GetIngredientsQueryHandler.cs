using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Application.IngredientLogic.Queries.GetIngredient;
using MediatR;

namespace BeadBE.Application.IngredientLogic.Queries.GetIngredients
{
    public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IngredientsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientsResult> Handle(GetIngredientsQuery query, CancellationToken cancellationToken)
        {
            return new IngredientsResult(await _unitOfWork.IngredientRepository.FindAllAsync());
        }
    }
}
