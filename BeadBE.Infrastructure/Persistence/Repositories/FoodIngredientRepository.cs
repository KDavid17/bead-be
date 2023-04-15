using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class FoodIngredientRepository : BaseRepository<FoodIngredient>, IFoodIngredientRepository
    {
        public FoodIngredientRepository(BeadContext context) : base(context) { }
    }
}
