using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionService.Entities;

namespace NutritionService.DataBase.Configurations;

public class MealIngredientConfiguration : IEntityTypeConfiguration<MealIngredient>
{
    public void Configure(EntityTypeBuilder<MealIngredient> builder)
    {
        builder.ToTable("MealIngredients");

        builder.HasKey(mi => mi.Id);


        builder.HasOne(mi => mi.Meal)
               .WithMany(m => m.MealIngredients)
               .HasForeignKey(mi => mi.MealId)
               .OnDelete(DeleteBehavior.Cascade);

        
    }
}
