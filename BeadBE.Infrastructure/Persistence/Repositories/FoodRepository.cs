using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(BeadContext context) : base(context) { }

        public async Task AddFoodWithIngredientsAsync(Food food, IEnumerable<Ingredient> ingredients)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            await executionStrategy.Execute(async () =>
            {
                using var transaction = _context.Database.BeginTransaction();

                await transaction.CreateSavepointAsync("BeforeBooking");

                try
                {
                    var newFood = await _context.Foods.AddAsync(food);

                    await _context.SaveChangesAsync();

                    foreach (var ingredient in ingredients)
                    {
                        await _context.FoodIngredients.AddAsync(new FoodIngredient()
                        {
                            FoodId = newFood.Entity.Id,
                            IngredientId = ingredient.Id
                        });
                    }

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackToSavepointAsync("BeforeBooking");

                    throw new OperationCanceledException("Failed and rolledback changes");
                }
            });
        }

        public async Task UpdateFoodWithIngredientsAsync(Food food, IEnumerable<Ingredient> ingredients)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            await executionStrategy.Execute(async () =>
            {
                using var transaction = _context.Database.BeginTransaction();

                await transaction.CreateSavepointAsync("BeforeBooking");

                try
                {
                    _context.Foods.Update(food);

                    await _context.SaveChangesAsync();

                    var oldIngredients = await _context.FoodIngredients.Where(fi => fi.FoodId == food.Id).ToListAsync();

                    foreach (var ingredient in oldIngredients.Where(oi => !ingredients.Any(i => i.Id == oi.IngredientId)))
                    {
                        _context.FoodIngredients.Remove(ingredient);
                    }

                    foreach (var ingredient in ingredients)
                    {
                        if (!oldIngredients.Any(oi => ingredient.Id == oi.IngredientId))
                        {
                            await _context.FoodIngredients.AddAsync(new FoodIngredient()
                            {
                                FoodId = food.Id,
                                IngredientId = ingredient.Id
                            });
                        }
                    }

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackToSavepointAsync("BeforeBooking");

                    throw new OperationCanceledException("Failed and rolledback changes");
                }
            });
        }

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
