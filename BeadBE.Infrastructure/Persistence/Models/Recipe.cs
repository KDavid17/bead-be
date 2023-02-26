using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int IngredientId { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
