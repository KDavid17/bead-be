using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.IngredientLogic.Commands.PutIngredient
{
    public class PutIngredientCommandHandler : IRequestHandler<PutIngredientCommand, IngredientResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutIngredientCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientResult> Handle(PutIngredientCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.IngredientRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Ingredient with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var ingredient = _mapper.Map<Ingredient>(command);

            await _unitOfWork.IngredientRepository.UpdateAsync(ingredient);

            return new IngredientResult(ingredient);
        }
    }
}
