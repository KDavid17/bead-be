using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Application.TableLogic.Queries.GetTable;
using MediatR;

namespace BeadBE.Application.TableLogic.Queries.GetTables
{
    public class GetTablesQueryHandler : IRequestHandler<GetTablesQuery, TablesResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTablesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TablesResult> Handle(GetTablesQuery query, CancellationToken cancellationToken)
        {
            return new TablesResult(await _unitOfWork.TableRepository.FindAllAsync());
        }
    }
}
