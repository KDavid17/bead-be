using BeadBE.Application.TableLogic.Common;
using MediatR;

namespace BeadBE.Application.TableLogic.Queries.GetTable
{
    public record GetTableQuery(int Id) : IRequest<TableResult>;
}
