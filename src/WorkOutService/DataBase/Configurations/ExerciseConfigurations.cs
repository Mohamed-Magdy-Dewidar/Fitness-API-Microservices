using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOutService.Entities;


namespace WorkoutService.Data.Configurations;

    public class ExerciseConfigurations : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            // Set explicit string lengths and required fields
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(e => e.TargetMuscleGroup).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Difficulty).IsRequired().HasMaxLength(50);
        }
    }
