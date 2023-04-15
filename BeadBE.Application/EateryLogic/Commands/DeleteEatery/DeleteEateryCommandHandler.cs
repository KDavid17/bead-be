using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.EateryLogic.Commands.DeleteEatery
{
    public class DeleteEateryCommandHandler : IRequestHandler<DeleteEateryCommand, EateryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEateryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EateryResult> Handle(DeleteEateryCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EateryRepository.FindByIdAsync(command.Id) is not Eatery eatery)
            {
                throw new BadHttpRequestException("Eatery with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.EateryRepository.RemoveAsync(eatery);

            return new EateryResult(eatery);
        }
    }
}
