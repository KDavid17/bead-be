using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingLogic.Common;
using MediatR;

namespace BeadBE.Application.BookingLogic.Queries.GetBookings
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, BookingsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingsResult> Handle(GetBookingsQuery query, CancellationToken cancellationToken)
        {
            return new BookingsResult(await _unitOfWork.BookingRepository.FindAllAsync());
        }
    }
}
