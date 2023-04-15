using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingFoodLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingFoodLogic.Commands.PutBookingFood
{
    public class PutBookingFoodCommandHandler : IRequestHandler<PutBookingFoodCommand, BookingFoodResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutBookingFoodCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingFoodResult> Handle(PutBookingFoodCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingFoodRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "BookingFood with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var bookingFood = _mapper.Map<BookingFood>(command);

            await _unitOfWork.BookingFoodRepository.UpdateAsync(bookingFood);

            return new BookingFoodResult(bookingFood);
        }
    }
}
