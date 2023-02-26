using System;
using System.Collections.Generic;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsAllergen { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
