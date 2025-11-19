using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkOutService.Entities;

namespace WorkoutService.Data.Configurations
{
    public class WorkoutExerciseConfigurations : IEntityTypeConfiguration<WorkoutExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
        {
            builder.ToTable("WorkoutExercises");

            // Composite Primary Key (Correct)
            builder.HasKey(we => new { we.WorkoutId, we.ExerciseId });

            // Workout relationship (Correct)
            builder.HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Exercise relationship (Correct)
            builder.HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict); // Changed to Restrict/NoAction for safety

           
            builder.HasIndex(we => we.Order);

            // Define constraints on context-specific columns
            builder.Property(we => we.Reps).IsRequired().HasMaxLength(50);
        }
    }
}