using BeadBE.Application.TableLogic.Commands.PutTable;
using BeadBE.Application.TableLogic.Common;
using BeadBE.Contract.Table;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class TableMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, TableRequest Request), PutTableCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<TableResult, TableResponse>()
                .Map(dest => dest, src => src.Table);

            config.NewConfig<TablesResult, TablesResponse>()
                .Map(dest => dest, src => src.Tables);
        }
    }
}
