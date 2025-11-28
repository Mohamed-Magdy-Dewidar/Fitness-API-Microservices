using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgressTrackingService.DataBase.Configurations;

public class CardioLogConfiguration : IEntityTypeConfiguration<CardioLog>
{
    public void Configure(EntityTypeBuilder<CardioLog> builder)
    {
        // Set precision for decimal types specific to CardioLog
        builder.Property(c => c.Distance).HasColumnType("decimal(18,2)");
        builder.Property(c => c.AveragePace).HasColumnType("decimal(18,2)");
        builder.Property(c => c.MaxSpeed).HasColumnType("decimal(18,2)");
    }
}
