using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.CellLogic.Commands.PutCell
{
    public class PutCellCommandHandler : IRequestHandler<PutCellCommand, CellResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutCellCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CellResult> Handle(PutCellCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CellRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Cell with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var cell = _mapper.Map<Cell>(command);

            await _unitOfWork.CellRepository.UpdateAsync(cell);

            return new CellResult(cell);
        }
    }
}
