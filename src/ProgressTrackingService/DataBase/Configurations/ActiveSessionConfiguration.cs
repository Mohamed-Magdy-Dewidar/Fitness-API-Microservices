using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgressTrackingService.Entities;

namespace ProgressTrackingService.DataBase.Configurations;

public class ActiveSessionConfiguration : IEntityTypeConfiguration<ActiveSession>
{
    public void Configure(EntityTypeBuilder<ActiveSession> builder)
    {
        builder.ToTable("ActiveSessions");        
        builder.HasIndex(a => a.UserId);
        builder.HasIndex(a => a.WorkoutId);
        builder.HasIndex(a => a.Status);
        builder.HasIndex(a => a.StartedAtUtc);

        builder.Property(a => a.Id).ValueGeneratedNever();


        // Soft delete filter
        builder.HasQueryFilter(a => !a.IsDeleted);
    }
}
