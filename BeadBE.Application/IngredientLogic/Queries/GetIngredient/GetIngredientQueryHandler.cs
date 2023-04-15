using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.IngredientLogic.Queries.GetIngredient
{
    public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, IngredientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientResult> Handle(GetIngredientQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.IngredientRepository.FindByIdAsync(query.Id) is not Ingredient ingredient)
            {
                throw new BadHttpRequestException(
                    "Ingredient with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new IngredientResult(ingredient);
        }
    }
}
