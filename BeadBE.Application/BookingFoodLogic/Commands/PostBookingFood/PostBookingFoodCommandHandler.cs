using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingFoodLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.BookingFoodLogic.Commands.PostBookingFood
{
    public class PostBookingFoodCommandHandler : IRequestHandler<PostBookingFoodCommand, BookingFoodResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostBookingFoodCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingFoodResult> Handle(PostBookingFoodCommand command, CancellationToken cancellationToken)
        {
            var bookingFood = _mapper.Map<BookingFood>(command);

            await _unitOfWork.BookingFoodRepository.AddAsync(bookingFood);

            return new BookingFoodResult(bookingFood);
        }
    }
}
