using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingCellLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BeadBE.Application.BookingCellLogic.Commands.PutBookingCell
{
    public class PutBookingCellCommandHandler : IRequestHandler<PutBookingCellCommand, BookingCellResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PutBookingCellCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingCellResult> Handle(PutBookingCellCommand command, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.BookingCellRepository.FindByIdAsync(command.Id) is null)
            {
                throw new BadHttpRequestException(
                    "BookingCell with provided ID not found!",
                    StatusCodes.Status404NotFound);
            }

            var bookingCell = _mapper.Map<BookingCell>(command);

            await _unitOfWork.BookingCellRepository.UpdateAsync(bookingCell);

            return new BookingCellResult(bookingCell);
        }
    }
}
