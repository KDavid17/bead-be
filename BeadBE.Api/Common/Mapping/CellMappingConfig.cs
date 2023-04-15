using BeadBE.Application.CellLogic.Commands.PutCell;
using BeadBE.Application.CellLogic.Common;
using BeadBE.Contract.Cell;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class CellMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, CellRequest Request), PutCellCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<CellResult, CellResponse>()
                .Map(dest => dest, src => src.Cell);

            config.NewConfig<CellsResult, CellsResponse>()
                .Map(dest => dest, src => src.Cells);
        }
    }
}
