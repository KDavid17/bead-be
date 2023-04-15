using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.CellLogic.Commands.DeleteCell
{
    public class DeleteCellCommandHandler : IRequestHandler<DeleteCellCommand, CellResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCellCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CellResult> Handle(DeleteCellCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CellRepository.FindByIdAsync(command.Id) is not Cell cell)
            {
                throw new BadHttpRequestException("Cell with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.CellRepository.RemoveAsync(cell);

            return new CellResult(cell);
        }
    }
}
