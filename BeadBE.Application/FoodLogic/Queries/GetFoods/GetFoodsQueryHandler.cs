using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Application.FoodLogic.Queries.GetFood;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoods
{
    public class GetFoodsQueryHandler : IRequestHandler<GetFoodsQuery, FoodsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FoodsResult> Handle(GetFoodsQuery query, CancellationToken cancellationToken)
        {
            return new FoodsResult(await _unitOfWork.FoodRepository.FindAllAsync());
        }
    }
}
