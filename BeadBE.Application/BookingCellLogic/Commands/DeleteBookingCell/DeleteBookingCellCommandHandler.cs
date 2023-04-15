using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingCellLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingCellLogic.Commands.DeleteBookingCell
{
    public class DeleteBookingCellCommandHandler : IRequestHandler<DeleteBookingCellCommand, BookingCellResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookingCellCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingCellResult> Handle(DeleteBookingCellCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingCellRepository.FindByIdAsync(command.Id) is not BookingCell bookingCell)
            {
                throw new BadHttpRequestException("BookingCell with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.BookingCellRepository.RemoveAsync(bookingCell);

            return new BookingCellResult(bookingCell);
        }
    }
}
