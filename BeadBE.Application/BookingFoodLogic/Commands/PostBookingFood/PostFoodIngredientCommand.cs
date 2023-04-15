using BeadBE.Application.BookingFoodLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingFoodLogic.Commands.PostBookingFood
{
    public record PostBookingFoodCommand(
        int BookingId,
        int FoodId) : IRequest<BookingFoodResult>;
}
