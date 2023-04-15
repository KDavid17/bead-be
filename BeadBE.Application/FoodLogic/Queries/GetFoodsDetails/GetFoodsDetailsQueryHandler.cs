using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodsDetails
{
    public class GetFoodsDetailsQueryHandler : IRequestHandler<GetFoodsDetailsQuery, FoodsDetailsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodsDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodsDetailsResult> Handle(GetFoodsDetailsQuery query, CancellationToken cancellationToken)
        {
            return new FoodsDetailsResult(await _unitOfWork.FoodRepository.FindAllFoodsWithDetailsAsync());
        }
    }
}
