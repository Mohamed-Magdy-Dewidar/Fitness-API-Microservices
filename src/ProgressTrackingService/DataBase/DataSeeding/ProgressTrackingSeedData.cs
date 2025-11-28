using ProgressTrackingService.Entities;
using Shared;

namespace ProgressTrackingService.DataBase.DataSeeding
{
    public static class ProgressTrackingSeedData
    {
        // --- Reusing User IDs from Shared ---
        private static readonly string User01_Id = SeedData.User01_Id; // Mohamed Magdy (Advanced/Complete Profile)
        private static readonly string User02_Id = SeedData.User02_Id; // Omar Mohamed (Intermediate/Partial Profile)

        // --- Sample Workout IDs (for logging) ---
        private static readonly Guid WkId_FullBody = new("9f0d4c0f-60a5-43h4-c25e-c29f12429d1f");
        private static readonly Guid WkId_ChestFocus = new("8e1e5d1e-71b6-44i3-d36f-d3ae1353ae20");

        // --- Sample Recipe IDs (for logging) ---
        public static readonly Guid RecipeId_Salmon = new("d1a1b2c3-1f2e-4d5c-9b8a-7e6d5f4c3b2a");
        public static readonly Guid RecipeId_Oatmeal = new("a1b2c3d4-4e3f-2a1b-0c9d-8e7f6a5b4c3d");

        // =================================================================
        // SEEDING METHODS
        // =================================================================

       

        public static IEnumerable<NutritionLog> GetNutritionLogs()
        {
            return new List<NutritionLog>
            {
                // User 01 - Sample Meal Log (Salmon)
                new NutritionLog {
                    UserId = User01_Id,
                    RecipeId = RecipeId_Salmon,
                    MealName = "Baked Salmon and Asparagus",
                    MealType = "Dinner",
                    TotalCalories = 550,
                    Protein = 50.0M,
                    Carbs = 15.0M,
                    Fats = 30.0M,
                    LoggedAtUtc = DateTime.UtcNow.AddHours(-12)
                },
                // User 01 - Sample Meal Log (Oatmeal)
                new NutritionLog {
                    UserId = User01_Id,
                    RecipeId = RecipeId_Oatmeal,
                    MealName = "Protein Oatmeal",
                    MealType = "Breakfast",
                    TotalCalories = 350,
                    Protein = 25.0M,
                    Carbs = 40.0M,
                    Fats = 10.0M,
                    LoggedAtUtc = DateTime.UtcNow.AddHours(-20)
                }
            };
        }

        public static IEnumerable<ActiveSession> GetActiveSessions()
        {
            // Simulates a user who is currently doing a workout that started 5 minutes ago.
            return new List<ActiveSession>
            {
                new ActiveSession
                {
                    Id = new Guid("c1a0170a-4b95-46f9-8c6f-a89a0717586a").ToString(),
                    UserId = User02_Id,
                    WorkoutId = WkId_ChestFocus,
                    WorkoutName = "Chest Builder",
                    StartedAtUtc = DateTime.UtcNow.AddMinutes(-5),
                    Status = ActivityStatus.InProgress,
                    PlannedDurationMinutes = 40,
                    DifficultyLevel = DifficultyLevels.Intermediate,
                    IsAbandoned = false
                }
            };
        }

        public static IEnumerable<WorkoutLog> GetCompletedWorkoutLogs()
        {
            // Simulates a completed Weight Log (User 01)
            var weightLog = new WeightLog
            {
                Id = new Guid("c1a0170a-4b95-46f9-8c6f-a89a0717586f"),
                UserId = User01_Id,
                WorkoutId = WkId_FullBody,
                WorkoutName = "Full Body Strength",
                SessionId = Guid.NewGuid().ToString(),
                CompletedAtUtc = DateTime.UtcNow.AddDays(-2),
                DurationMinutes = 45,
                CaloriesBurned = 350,
                LogType = "Weight",
                Sets = 15,
                Reps = 10,
                WeightLifted = 80.0M,
                Notes = "Good energy today.",
            };

            // Simulates a completed Cardio Log (User 01)
            var cardioLog = new CardioLog
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                UserId = User01_Id,
                WorkoutId = WkId_FullBody,
                WorkoutName = "Morning Run",
                SessionId = Guid.NewGuid().ToString(),
                CompletedAtUtc = DateTime.UtcNow.AddDays(-1),
                DurationMinutes = 30,
                CaloriesBurned = 280,
                LogType = "Cardio",
                Distance = 5.0M,
                DistanceUnit = "km",
                AverageHeartRate = 145,
                AveragePace = 6.0M,
            };

            return new List<WorkoutLog> { weightLog, cardioLog };
        }
    }
}