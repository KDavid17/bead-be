using BeadBE.Application.Common.Interfaces.Persistence.Repositories;

namespace BeadBE.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IBookingRepository BookingRepository { get; }
        IBookingCellRepository BookingCellRepository { get; }
        IBookingFoodRepository BookingFoodRepository { get; }
        ICellRepository CellRepository { get; }
        IFoodRepository FoodRepository { get; }
        IFoodIngredientRepository FoodIngredientRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IEateryRepository EateryRepository { get; }
        ITableRepository TableRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
        Task CommitAsync();
        void RollBackAsync();
    }
}
