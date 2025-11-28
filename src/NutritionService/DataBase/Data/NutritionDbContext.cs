

using Microsoft.EntityFrameworkCore;
using NutritionService.Entities;

namespace NutritionService.DataBase.Data
{
    public class NutritionDbContext : DbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options)
        {
        }
        
        public DbSet<Meal> meals { get; set; }
        public DbSet<MealIngredient> mealIngredients { get; set; }
        public DbSet<MealPlan> mealPlans { get; set; }
        public DbSet<NutritionFact> nutritionFacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutritionDbContext).Assembly);
        }


    }
}
