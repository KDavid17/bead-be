using System;
using System.Collections.Generic;

namespace BeadBE.Domain.Entities;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsAllergen { get; set; }

    public virtual ICollection<FoodIngredient> FoodIngredients { get; } = new List<FoodIngredient>();
}
