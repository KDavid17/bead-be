using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.CellLogic.Queries.GetCell
{
    public class GetCellQueryHandler : IRequestHandler<GetCellQuery, CellResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCellQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CellResult> Handle(GetCellQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CellRepository.FindByIdAsync(query.Id) is not Cell cell)
            {
                throw new BadHttpRequestException(
                    "Cell with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new CellResult(cell);
        }
    }
}
