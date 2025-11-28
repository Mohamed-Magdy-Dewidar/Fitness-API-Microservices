using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.DataBase.Configurations;

public class WorkoutLogConfiguration : IEntityTypeConfiguration<WorkoutLog>
{
    public void Configure(EntityTypeBuilder<WorkoutLog> builder)
    {
        builder.ToTable("WorkoutLogs");

        // CRITICAL: Configure TPH Discriminator
        builder.HasDiscriminator<string>("LogType")
            .HasValue<WeightLog>("Weight")
            .HasValue<CardioLog>("Cardio")
            .HasValue<TimedLog>("Timed");

        builder.HasIndex(w => w.UserId);
        builder.HasIndex(w => w.CompletedAtUtc);

        // Soft delete filter
        builder.HasQueryFilter(w => !w.IsDeleted);
    }
}
