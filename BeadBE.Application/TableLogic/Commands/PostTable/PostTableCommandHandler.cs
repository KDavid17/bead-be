using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.TableLogic.Commands.PostTable
{
    public class PostTableCommandHandler : IRequestHandler<PostTableCommand, TableResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostTableCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TableResult> Handle(PostTableCommand command, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(command);

            await _unitOfWork.TableRepository.AddAsync(table);

            return new TableResult(table);
        }
    }
}
