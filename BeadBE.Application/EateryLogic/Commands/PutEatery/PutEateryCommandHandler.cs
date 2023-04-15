using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.EateryLogic.Commands.PutEatery
{
    public class PutEateryCommandHandler : IRequestHandler<PutEateryCommand, EateryResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutEateryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<EateryResult> Handle(PutEateryCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.EateryRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Eatery with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var eatery = _mapper.Map<Eatery>(command);

            await _unitOfWork.EateryRepository.UpdateAsync(eatery);

            return new EateryResult(eatery);
        }
    }
}
