using BeadBE.Application.Common.Interfaces.Persistence.Repositories;
using BeadBE.Domain.Entities;
using BeadBE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BeadContext context) : base(context) { }

        public async Task AddBookingWithFoodsAsync(Booking booking, IEnumerable<BookingFood> preOrderedFoods)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            await executionStrategy.Execute(async () =>
            {
                using var transaction = _context.Database.BeginTransaction();

                await transaction.CreateSavepointAsync("BeforeBooking");

                try
                {
                    var newBooking = _context.Bookings.Add(booking);

                    await _context.SaveChangesAsync();

                    foreach (var bookingFood in preOrderedFoods)
                    {
                        await _context.BookingFoods.AddAsync(new BookingFood()
                        {
                            BookingId = newBooking.Entity.Id,
                            FoodId = bookingFood.FoodId,
                            Quantity = bookingFood.Quantity,
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

        public async Task<IEnumerable<BookingDetails>> GetBookingsByUserIdAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Eatery)
                .Include(b => b.BookingFoods)
                    .ThenInclude(bf => bf.Food.FoodIngredients)
                .Where(b => b.UserId == userId)
                .Select(b => new BookingDetails()
                {
                    Id = b.Id,
                    EateryId = b.EateryId,
                    EateryName = b.Eatery.Name,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    Foods = b.BookingFoods.Select(bf => new FoodDetails
                    {
                        Id = bf.Food.Id,
                        EateryId = bf.Food.EateryId,
                        Name = bf.Food.Name,
                        Price = bf.Food.Price,
                        Ingredients = bf.Food.FoodIngredients.Select(fi => fi.Ingredient),
                        Quantity = bf.Quantity,
                    })
                })
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();
        }
    }
}
