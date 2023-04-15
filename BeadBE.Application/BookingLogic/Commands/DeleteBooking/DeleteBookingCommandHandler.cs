using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingLogic.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, BookingResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingResult> Handle(DeleteBookingCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingRepository.FindByIdAsync(command.Id) is not Booking booking)
            {
                throw new BadHttpRequestException("Booking with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.BookingRepository.RemoveAsync(booking);

            return new BookingResult(booking);
        }
    }
}
