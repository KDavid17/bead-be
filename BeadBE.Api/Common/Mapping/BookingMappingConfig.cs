using BeadBE.Application.BookingLogic.Commands.PutBooking;
using BeadBE.Application.BookingLogic.Common;
using BeadBE.Contract.Booking;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class BookingMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, BookingRequest Request), PutBookingCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<BookingResult, BookingResponse>()
                .Map(dest => dest, src => src.Booking);

            config.NewConfig<BookingsResult, BookingsResponse>()
                .Map(dest => dest, src => src.Bookings);
        }
    }
}
