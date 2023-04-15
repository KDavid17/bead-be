using BeadBE.Application.BookingCellLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingCellLogic.Commands.PostBookingCell
{
    public record PostBookingCellCommand(
        int BookingId,
        int CellId) : IRequest<BookingCellResult>;
}
