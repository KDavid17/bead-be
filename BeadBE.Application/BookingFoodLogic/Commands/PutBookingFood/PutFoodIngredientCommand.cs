using BeadBE.Application.BookingFoodLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingFoodLogic.Commands.PutBookingFood
{
    public record PutBookingFoodCommand(
        int Id,
        int BookingId,
        int FoodId) : IRequest<BookingFoodResult>;
}
