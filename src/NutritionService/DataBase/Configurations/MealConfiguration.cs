using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionService.Entities;
using NutritionService.Entities.Enums;

namespace NutritionService.DataBase.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meals");

        builder.HasKey(m => m.Id);


        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.mealType)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(50).HasDefaultValue(MealType.Breakfast);


        builder.HasOne(m => m.MealPlan)
               .WithMany(mp => mp.Meals)
               .HasForeignKey(m => m.MealPlanId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.NutritionFacts)
               .WithOne(nf => nf.Meal)
               .HasForeignKey<NutritionFact>(nf => nf.Id)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.MealIngredients)
               .WithOne(mi => mi.Meal)
               .HasForeignKey(mi => mi.MealId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
