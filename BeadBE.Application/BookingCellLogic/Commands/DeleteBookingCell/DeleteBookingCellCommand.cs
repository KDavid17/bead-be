using BeadBE.Application.BookingCellLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingCellLogic.Commands.DeleteBookingCell
{
    public record DeleteBookingCellCommand(int Id) : IRequest<BookingCellResult>;
}
