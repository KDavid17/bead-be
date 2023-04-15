using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.FoodLogic.Commands.PutFood
{
    public class PutFoodCommandHandler : IRequestHandler<PutFoodCommand, FoodResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutFoodCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodResult> Handle(PutFoodCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.FoodRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Food with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var food = _mapper.Map<Food>(command);

            await _unitOfWork.FoodRepository.UpdateAsync(food);

            return new FoodResult(food);
        }
    }
}
