using BeadBE.Application.TableLogic.Common;
using MediatR;

namespace BeadBE.Application.TableLogic.Queries.GetTable
{
    public record GetTablesQuery() : IRequest<TablesResult>;
}
