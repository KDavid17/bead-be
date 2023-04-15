using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.TableLogic.Commands.DeleteTable
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, TableResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTableCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TableResult> Handle(DeleteTableCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TableRepository.FindByIdAsync(command.Id) is not Table table)
            {
                throw new BadHttpRequestException("Table with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.TableRepository.RemoveAsync(table);

            return new TableResult(table);
        }
    }
}
