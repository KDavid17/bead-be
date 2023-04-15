using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.TableLogic.Queries.GetTable
{
    public class GetTableQueryHandler : IRequestHandler<GetTableQuery, TableResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTableQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TableResult> Handle(GetTableQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.TableRepository.FindByIdAsync(query.Id) is not Table table)
            {
                throw new BadHttpRequestException(
                    "Table with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new TableResult(table);
        }
    }
}
