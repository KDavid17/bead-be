using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.CellLogic.Commands.PostCell
{
    public class PostCellCommandHandler : IRequestHandler<PostCellCommand, CellResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostCellCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CellResult> Handle(PostCellCommand command, CancellationToken cancellationToken)
        {
            var cell = _mapper.Map<Cell>(command);

            await _unitOfWork.CellRepository.AddAsync(cell);

            return new CellResult(cell);
        }
    }
}
