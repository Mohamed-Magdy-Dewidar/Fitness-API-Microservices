using Microsoft.EntityFrameworkCore;
using WorkOutService.Entities;


namespace WorkOutService.DataBase;

public class WorkoutDbContext : DbContext
{
    public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options)
    {        
    }

    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkOutAssemblyReference).Assembly);
    }

}

