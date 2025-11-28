using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Entities;



namespace ProgressTrackingService.DataBase;

public class ProgressTrackingDbContext : DbContext
{
    public ProgressTrackingDbContext(DbContextOptions<ProgressTrackingDbContext> options) : base(options)
    {        
    }


    public DbSet<ActiveSession> ActiveSessions { get; set; }
    public DbSet<WorkoutLog> WorkoutLogs { get; set; } // Base DbSet for TPH
    public DbSet<NutritionLog> NutritionLogs { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgressTrackingAssemblyReference).Assembly);
    }

}

