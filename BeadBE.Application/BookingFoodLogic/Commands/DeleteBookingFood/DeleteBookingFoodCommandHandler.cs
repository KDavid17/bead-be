using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingFoodLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingFoodLogic.Commands.DeleteBookingFood
{
    public class DeleteBookingFoodCommandHandler : IRequestHandler<DeleteBookingFoodCommand, BookingFoodResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookingFoodCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingFoodResult> Handle(DeleteBookingFoodCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingFoodRepository.FindByIdAsync(command.Id) is not BookingFood bookingFood)
            {
                throw new BadHttpRequestException("BookingFood with provided ID not found!", StatusCodes.Status404NotFound);
            }

            await _unitOfWork.BookingFoodRepository.RemoveAsync(bookingFood);

            return new BookingFoodResult(bookingFood);
        }
    }
}
