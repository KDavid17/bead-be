using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Food
{
    public int Id { get; set; }

    public int EateryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<BookingFood> BookingFoods { get; } = new List<BookingFood>();

    public virtual Eatery Eatery { get; set; } = null!;

    public virtual ICollection<FoodIngredient> FoodIngredients { get; } = new List<FoodIngredient>();
}
