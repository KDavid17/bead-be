using BeadBE.Application.BookingCellLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingCellLogic.Commands.PutBookingCell
{
    public record PutBookingCellCommand(
        int Id,
        int BookingId,
        int CellId) : IRequest<BookingCellResult>;
}
