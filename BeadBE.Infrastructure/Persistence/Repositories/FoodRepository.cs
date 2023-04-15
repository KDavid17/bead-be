using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(BeadContext context) : base(context) { }

        public async Task<IEnumerable<FoodDetails>> FindAllFoodsWithDetailsAsync()
        {
            return await _context.Foods
                                .AsNoTracking()
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
                                .ToListAsync();
        }
    }
}
