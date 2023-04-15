using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingLogic.Common;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingLogic.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingResult> Handle(GetBookingQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingRepository.FindByIdAsync(query.Id) is not Booking booking)
            {
                throw new BadHttpRequestException(
                    "Booking with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new BookingResult(booking);
        }
    }
}
