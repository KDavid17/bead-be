using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.BookingLogic.Commands.PostBooking
{
    public class PostBookingCommandHandler : IRequestHandler<PostBookingCommand, BookingResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostBookingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingResult> Handle(PostBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = _mapper.Map<Booking>(command);

            if (booking.DidOrder)
            {
                var preOrderedFoods = command.PreOrderedFoods;

                await _unitOfWork.BookingRepository.AddBookingWithFoodsAsync(booking, preOrderedFoods);
            } 
            else
            {
                await _unitOfWork.BookingRepository.AddAsync(booking);
            }

            return new BookingResult(booking);
        }
    }
}
