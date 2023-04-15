using BeadBE.Application.BookingFoodLogic.Commands.PutBookingFood;
using BeadBE.Contract.BookingFood;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class BookingFoodMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, BookingFoodRequest Request), PutBookingFoodCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);
        }
    }
}
