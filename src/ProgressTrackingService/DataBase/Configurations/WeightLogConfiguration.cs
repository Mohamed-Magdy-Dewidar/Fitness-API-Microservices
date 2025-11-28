using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgressTrackingService.DataBase.Configurations;

public class WeightLogConfiguration : IEntityTypeConfiguration<WeightLog>
{
    public void Configure(EntityTypeBuilder<WeightLog> builder)
    {
        // Set precision for decimal types specific to WeightLog
        builder.Property(w => w.WeightLifted).HasColumnType("decimal(18,2)");
    }
}
