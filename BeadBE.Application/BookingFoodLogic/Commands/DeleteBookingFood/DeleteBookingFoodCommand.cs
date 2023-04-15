using BeadBE.Application.BookingFoodLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingFoodLogic.Commands.DeleteBookingFood
{
    public record DeleteBookingFoodCommand(int Id) : IRequest<BookingFoodResult>;
}
