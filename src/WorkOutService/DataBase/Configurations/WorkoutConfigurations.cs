using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOutService.Entities;

namespace WorkoutService.Data.Configurations
{
    public class WorkoutConfigurations : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workouts");
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            // Set explicit string lengths and required fields
            builder.Property(w => w.Name).IsRequired().HasMaxLength(200);
            builder.Property(w => w.Description).IsRequired().HasMaxLength(2000);
            builder.Property(w => w.Category).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Difficulty).IsRequired().HasMaxLength(50);
            builder.Property(w => w.Tags).HasMaxLength(500);

            // Add index for fast querying by category (Good job on this!)
            builder.HasIndex(w => w.Category);
        }
    }
}