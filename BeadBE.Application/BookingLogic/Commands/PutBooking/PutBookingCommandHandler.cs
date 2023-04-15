using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingLogic.Commands.PutBooking
{
    public class PutBookingCommandHandler : IRequestHandler<PutBookingCommand, BookingResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutBookingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingResult> Handle(PutBookingCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "Booking with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            if (await _unitOfWork.EateryRepository.FindByIdAsync(command.EateryId) is not Eatery eatery)
            {
                throw new BadHttpRequestException(
                    "Eatery with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            if (await _unitOfWork.UserRepository.FindByIdAsync(command.UserId) is null)
            {
                throw new BadHttpRequestException(
                    "User with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            /*if (command.CallerUserId != eatery.UserId)
            {
                throw new BadHttpRequestException(
                    "Modifying bookings made for other eateries is prohibited!",
                    StatusCodes.Status403Forbidden);
            }*/

            var booking = _mapper.Map<Booking>(command);

            await _unitOfWork.BookingRepository.UpdateAsync(booking);

            return new BookingResult(booking);
        }
    }
}
