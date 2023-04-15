using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.IngredientLogic.Commands.DeleteIngredient
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, IngredientResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIngredientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientResult> Handle(DeleteIngredientCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.IngredientRepository.FindByIdAsync(command.Id) is not Ingredient ingredient)
            {
                throw new BadHttpRequestException("Ingredient with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.IngredientRepository.RemoveAsync(ingredient);

            return new IngredientResult(ingredient);
        }
    }
}
