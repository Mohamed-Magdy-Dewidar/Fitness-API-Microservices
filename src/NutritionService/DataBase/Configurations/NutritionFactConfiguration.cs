using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionService.Entities;

namespace NutritionService.DataBase.Configurations;

public class NutritionFactConfiguration : IEntityTypeConfiguration<NutritionFact>
{
    public void Configure(EntityTypeBuilder<NutritionFact> builder)
    {
        builder.HasKey(n => n.Id);



        builder.HasOne(n => n.Meal)
               .WithOne(m => m.NutritionFacts)
               .HasForeignKey<NutritionFact>(n => n.MealId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
