using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Infrastructure.Persistence.Repositories;

namespace BeadBE.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BeadContext _context;

        private IBookingRepository _bookingRepository;
        private IBookingCellRepository _bookingCellRepository;
        private IBookingFoodRepository _bookingFoodRepository;
        private ICellRepository _cellRepository;
        private IEateryRepository _eateryRepository;
        private IFoodRepository _foodRepository;
        private IFoodIngredientRepository _foodIngredientRepository;
        private IIngredientRepository _ingredientRepository;
        private ITableRepository _tableRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(BeadContext context)
        {
            _context = context;
        }

        public IBookingRepository BookingRepository
            => _bookingRepository ??= new BookingRepository(_context);

        public IBookingCellRepository BookingCellRepository
            => _bookingCellRepository ??= new BookingCellRepository(_context);

        public IBookingFoodRepository BookingFoodRepository
            => _bookingFoodRepository ??= new BookingFoodRepository(_context);

        public ICellRepository CellRepository
            => _cellRepository ??= new CellRepository(_context);

        public IEateryRepository EateryRepository
            => _eateryRepository ??= new EateryRepository(_context);

        public IFoodRepository FoodRepository
            => _foodRepository ??= new FoodRepository(_context);

        public IFoodIngredientRepository FoodIngredientRepository
            => _foodIngredientRepository ??= new FoodIngredientRepository(_context);

        public IIngredientRepository IngredientRepository
            => _ingredientRepository ??= new IngredientRepository(_context);

        public ITableRepository TableRepository
            => _tableRepository ??= new TableRepository(_context);

        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void RollBackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
