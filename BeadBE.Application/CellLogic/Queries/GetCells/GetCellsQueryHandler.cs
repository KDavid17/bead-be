using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Application.CellLogic.Queries.GetCell;
using MediatR;

namespace BeadBE.Application.CellLogic.Queries.GetCells
{
    public class GetCellsQueryHandler : IRequestHandler<GetCellsQuery, CellsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCellsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CellsResult> Handle(GetCellsQuery query, CancellationToken cancellationToken)
        {
            return new CellsResult(await _unitOfWork.CellRepository.FindAllAsync());
        }
    }
}
