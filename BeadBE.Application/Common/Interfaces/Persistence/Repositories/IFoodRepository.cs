using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;

namespace BeadBE.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IFoodRepository : IBaseRepository<Food>
    {
        public Task AddFoodWithIngredientsAsync(Food food, IEnumerable<Ingredient> ingredients);
        public Task UpdateFoodWithIngredientsAsync(Food food, IEnumerable<Ingredient> ingredients);
        public Task<FoodDetails?> FindFoodWithDetailsByIdAsync(int id);
        public Task<IEnumerable<FoodDetails>> FindFoodsWithDetailsByEateryIdAsync(int id);
    }
}
