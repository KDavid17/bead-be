using BeadBE.Application.BookingCellLogic.Commands.PutBookingCell;
using BeadBE.Contract.BookingCell;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class BookingCellMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, BookingCellRequest Request), PutBookingCellCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);
        }
    }
}
