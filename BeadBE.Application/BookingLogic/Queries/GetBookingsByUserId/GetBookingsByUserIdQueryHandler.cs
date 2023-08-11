using BeadBE.Application.BookingLogic.Common;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingLogic.Queries.GetBookingsByUserId
{
    public class GetBookingsByUserIdQueryHandler : IRequestHandler<GetBookingsByUserIdQuery, BookingsDetailsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookingsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingsDetailsResult> Handle(GetBookingsByUserIdQuery query, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.FindByIdAsync(query.UserId) is null)
            {
                throw new BadHttpRequestException(
                    "User with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            return new BookingsDetailsResult(await _unitOfWork.BookingRepository.GetBookingsByUserIdAsync(query.UserId));
        }
    }
}
