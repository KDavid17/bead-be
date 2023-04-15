using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.EateryLogic.Commands.PostEatery
{
    public class PostEateryCommandHandler : IRequestHandler<PostEateryCommand, EateryResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostEateryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<EateryResult> Handle(PostEateryCommand command, CancellationToken cancellationToken)
        {
            var eatery = _mapper.Map<Eatery>(command);

            await _unitOfWork.EateryRepository.AddAsync(eatery);

            return new EateryResult(eatery);
        }
    }
}
