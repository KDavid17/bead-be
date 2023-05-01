using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(BeadContext context) : base(context) { }

        public async Task<FoodDetails?> FindFoodWithDetailsByIdAsync(int id)
        {
            return await _context.Foods
                .Include(f => f.FoodIngredients)
                    .ThenInclude(fi => fi.Ingredient)
                .Select(f => new FoodDetails
                {
                    Id = f.Id,
                    EateryId = f.EateryId,
                    Name = f.Name,
                    Price = f.Price,
                    Ingredients = f.FoodIngredients.Select(fi => fi.Ingredient)
                })
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<FoodDetails>> FindFoodsWithDetailsByEateryIdAsync(int id)
        {
            return await _context.Foods
                .Include(f => f.FoodIngredients)
                    .ThenInclude(fi => fi.Ingredient)
                .Select(f => new FoodDetails
                {
                    Id = f.Id,
                    EateryId = f.EateryId,
                    Name = f.Name,
                    Price = f.Price,
                    Ingredients = f.FoodIngredients.Select(fi => fi.Ingredient)
                })
                .Where(f => f.EateryId == id)
                .ToListAsync();
        }
    }
}
