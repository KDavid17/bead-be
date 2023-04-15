using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.BookingCellLogic.Common;
using BeadBE.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BeadBE.Application.BookingCellLogic.Commands.PostBookingCell
{
    public class PostBookingCellCommandHandler : IRequestHandler<PostBookingCellCommand, BookingCellResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostBookingCellCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingCellResult> Handle(PostBookingCellCommand command, CancellationToken cancellationToken)
        {
            var bookingCell = _mapper.Map<BookingCell>(command);

            await _unitOfWork.BookingCellRepository.AddAsync(bookingCell);

            return new BookingCellResult(bookingCell);
        }
    }
}
