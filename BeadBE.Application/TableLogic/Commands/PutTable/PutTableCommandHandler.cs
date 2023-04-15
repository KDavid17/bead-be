using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.TableLogic.Commands.PutTable
{
    public class PutTableCommandHandler : IRequestHandler<PutTableCommand, TableResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutTableCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TableResult> Handle(PutTableCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TableRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Table with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var table = _mapper.Map<Table>(command);

            await _unitOfWork.TableRepository.UpdateAsync(table);

            return new TableResult(table);
        }
    }
}
