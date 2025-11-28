using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.DataBase.Configurations;

public class NutritionLogConfiguration : IEntityTypeConfiguration<NutritionLog>
{
    public void Configure(EntityTypeBuilder<NutritionLog> builder)
    {
        builder.ToTable("NutritionLogs");

        // Set precision for nutritional macros
        builder.Property(n => n.Protein).HasColumnType("decimal(18,2)");
        builder.Property(n => n.Carbs).HasColumnType("decimal(18,2)");
        builder.Property(n => n.Fats).HasColumnType("decimal(18,2)");

        builder.HasIndex(n => n.UserId);
        builder.HasIndex(n => n.LoggedAtUtc);

        // Soft delete filter
        builder.HasQueryFilter(n => !n.IsDeleted);
    }
}
