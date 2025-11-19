namespace WorkOutService.DataBase.DataSeeding;
using Shared;
using WorkOutService.Entities;



public static class WorkoutSeedData
{
    // ==================== EXERCISE IDs ====================
    // Chest Exercises
         public static readonly Guid ExId_Pushup = new("c1a0170a-4b95-46f9-8c6f-a89a0717586a");
         public static readonly Guid ExId_InclinePushup = new("c1a0170a-4b95-46f9-8c6f-a89a0717586b");
         public static readonly Guid ExId_DeclinePushup = new("c1a0170a-4b95-46f9-8c6f-a89a0717586c");
         public static readonly Guid ExId_DiamondPushup = new("c1a0170a-4b95-46f9-8c6f-a89a0717586d");
         public static readonly Guid ExId_ChestPress = new("c1a0170a-4b95-46f9-8c6f-a89a0717586e");
         public static readonly Guid ExId_ChestFly = new("c1a0170a-4b95-46f9-8c6f-a89a0717586f");
         public static readonly Guid ExId_BenchPress = new("c1a0170a-4b95-46f9-8c6f-a89a07175870");


    // Leg Exercises
    public static readonly Guid ExId_Squat = new("a2b1280b-2b6d-49d8-9c1a-8c5b0818597b");
    public static readonly Guid ExId_Lunge = new("a2b1280b-2b6d-49d8-9c1a-8c5b0818597c");
    public static readonly Guid ExId_BulgarianSplitSquat = new("a2b1280b-2b6d-49d8-9c1a-8c5b0818597d");
    public static readonly Guid ExId_LegPress = new("a2b1280b-2b6d-49d8-9c1a-8c5b0818597e");
    public static readonly Guid ExId_LegCurl = new("a2b1280b-2b6d-49d8-9c1a-8c5b0818597f");
    public static readonly Guid ExId_CalfRaise = new("a2b1280b-2b6d-49d8-9c1a-8c5b08185980");
    public static readonly Guid ExId_Deadlift = new("a2b1280b-2b6d-49d8-9c1a-8c5b08185981");
    public static readonly Guid ExId_RomanianDeadlift = new("a2b1280b-2b6d-49d8-9c1a-8c5b08185982");
    public static readonly Guid ExId_GobletSquat = new("a2b1280b-2b6d-49d8-9c1a-8c5b08185983");
    public static readonly Guid ExId_WallSit = new("a2b1280b-2b6d-49d8-9c1a-8c5b08185984");


    // Back Exercises
    public static readonly Guid ExId_DBRow = new("e4d34a0d-4e8f-41f6-b03c-a07d10207b9d");
        public static readonly Guid ExId_BentOverRow = new("e4d34a0d-4e8f-41f6-b03c-a07d10207b9e");
        public static readonly Guid ExId_PullUp = new("e4d34a0d-4e8f-41f6-b03c-a07d10207b9f");
        public static readonly Guid ExId_LatPulldown = new("e4d34a0d-4e8f-41f6-b03c-a07d10207ba0");
        public static readonly Guid ExId_SeatedRow = new("e4d34a0d-4e8f-41f6-b03c-a07d10207ba1");
        public static readonly Guid ExId_TBarRow = new("e4d34a0d-4e8f-41f6-b03c-a07d10207ba2");
        public static readonly Guid ExId_SupermanHold = new("e4d34a0d-4e8f-41f6-b03c-a07d10207ba3");

        // Shoulder Exercises
        public static readonly Guid ExId_ShoulderPress = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a8d");
        public static readonly Guid ExId_LateralRaise = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a8e");
        public static readonly Guid ExId_FrontRaise = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a8f");
        public static readonly Guid ExId_RearDeltFly = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a90");
        public static readonly Guid ExId_ArnoldPress = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a91");
        public static readonly Guid ExId_Shrugs = new("b3c2390c-3d7e-40e7-a92b-9d6c09196a92");

    // Arm Exercises
    public static readonly Guid ExId_BicepCurl = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c0f");
    public static readonly Guid ExId_HammerCurl = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c10");
    public static readonly Guid ExId_TricepDip = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c11");
    public static readonly Guid ExId_TricepExtension = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c12");
    public static readonly Guid ExId_SkullCrusher = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c13");
    public static readonly Guid ExId_ConcentrationCurl = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c14");


    // Core Exercises
    public static readonly Guid ExId_Plank = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a8c");
    public static readonly Guid ExId_SidePlank = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a8e");
    public static readonly Guid ExId_Crunches = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a8f");
    public static readonly Guid ExId_BicycleCrunches = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a90");
    public static readonly Guid ExId_LegRaise = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a91");
    public static readonly Guid ExId_RussianTwist = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a92");
    public static readonly Guid ExId_MountainClimber = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a93");
    public static readonly Guid ExId_AbWheel = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a94");
    public static readonly Guid ExId_HangingKneeRaise = new("d3c2390c-3d7e-40e7-a92b-9d6c09196a95");


    // Cardio/HIIT Exercises
    public static readonly Guid ExId_JumpingJack = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c0e");
    public static readonly Guid ExId_Burpee = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c15");
    public static readonly Guid ExId_HighKnees = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c16");
    public static readonly Guid ExId_ButtKicks = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c17");
    public static readonly Guid ExId_JumpSquat = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c18");
    public static readonly Guid ExId_BoxJump = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c19");
    public static readonly Guid ExId_JumpLunge = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c1a");
    public static readonly Guid ExId_BearCrawl = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c1b");
    public static readonly Guid ExId_SprintInterval = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c1c");
    public static readonly Guid ExId_RopeJump = new("f5e45b0e-5f9a-42a5-b14d-b18e11318c1d");


    // Functional/Olympic
    public static readonly Guid ExId_KettlebellSwing = new("a6f56c1f-6f0b-43b6-c26f-c30a13530e2a");
    public static readonly Guid ExId_CleanAndPress = new("a6f56c1f-6f0b-43b6-c26f-c30a13530e2b");
    public static readonly Guid ExId_TurkishGetUp = new("a6f56c1f-6f0b-43b6-c26f-c30a13530e2c");
    public static readonly Guid ExId_Thruster = new("a6f56c1f-6f0b-43b6-c26f-c30a13530e2d");
    public static readonly Guid ExId_WallBall = new("a6f56c1f-6f0b-43b6-c26f-c30a13530e2e");


    // ==================== WORKOUT IDs ====================
    public static readonly Guid WkId_FullBody = new("9f0d4c0f-60a5-43a4-b25e-c29f12429d1f");
    public static readonly Guid WkId_ChestFocus = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae20");
    public static readonly Guid WkId_LegDay = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae21");
    public static readonly Guid WkId_BackAndBiceps = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae22");
    public static readonly Guid WkId_ShoulderBlaster = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae23");
    public static readonly Guid WkId_CoreCrusher = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae24");
    public static readonly Guid WkId_HIITCardio = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae25");
    public static readonly Guid WkId_BeginnerFullBody = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae26");
    public static readonly Guid WkId_UpperBodyPush = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae27");
    public static readonly Guid WkId_UpperBodyPull = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae28");
    public static readonly Guid WkId_LowerBodyPower = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae29");
    public static readonly Guid WkId_ArmsAndAbs = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2a");
    public static readonly Guid WkId_QuickMorning = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2b");
    public static readonly Guid WkId_AtHomeBodyweight = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2c");
    public static readonly Guid WkId_AdvancedHIIT = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2d");
    public static readonly Guid WkId_StrengthBuilder = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2e");
    public static readonly Guid WkId_FatBurner = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae2f");
    public static readonly Guid WkId_PushPull = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae30");
    public static readonly Guid WkId_LegStrength = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae31");
    public static readonly Guid WkId_ChestAndBack = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae32");
    public static readonly Guid WkId_TotalBodyConditioning = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae33");
    public static readonly Guid WkId_CoreStability = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae34");
    public static readonly Guid WkId_BeginnerCardio = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae35");
    public static readonly Guid WkId_PowerlifterBasics = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae36");
    public static readonly Guid WkId_FunctionalFitness = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae37");
    public static readonly Guid WkId_AthleticPerformance = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae38");
    public static readonly Guid WkId_MobilityAndStrength = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae39");
    public static readonly Guid WkId_BodybuildingChest = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3a");
    public static readonly Guid WkId_BodybuildingBack = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3b");
    public static readonly Guid WkId_BodybuildingLegs = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3c");
    public static readonly Guid WkId_BodybuildingShoulders = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3d");
    public static readonly Guid WkId_BodybuildingArms = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3e");
    public static readonly Guid WkId_CrossTraining = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae3f");
    public static readonly Guid WkId_MetabolicConditioning = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae40");
    public static readonly Guid WkId_ExplosivePower = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae41");
    public static readonly Guid WkId_Endurance = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae42");
    public static readonly Guid WkId_RecoveryDay = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae43");
    public static readonly Guid WkId_30MinFullBody = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae44");
    public static readonly Guid WkId_20MinHIIT = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae45");
    public static readonly Guid WkId_QuickCore = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae46");
    public static readonly Guid WkId_UpperLowerSplit = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae47");
    public static readonly Guid WkId_CompoundMovements = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae48");
    public static readonly Guid WkId_IsolationWork = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae49");
    public static readonly Guid WkId_CardioCore = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4a");
    public static readonly Guid WkId_StrengthEndurance = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4b");
    public static readonly Guid WkId_PlyometricPower = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4c");
    public static readonly Guid WkId_CircuitTraining = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4d");
    public static readonly Guid WkId_AdvancedAthlete = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4e");
    public static readonly Guid WkId_WeightLossSpecial = new("8e1e5d1e-71b6-44a3-a36f-d3ae1353ae4f");


    // ==================== EXERCISE DEFINITIONS ====================
    public static IEnumerable<Exercise> GetExercises()
        {
            return new List<Exercise>
            {
                // Chest Exercises
                new Exercise { Id = ExId_Pushup, Name = "Push-ups", TargetMuscleGroup = "Chest, Triceps, Shoulders", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Keep body straight, lower chest to ground, push back up." },
                new Exercise { Id = ExId_InclinePushup, Name = "Incline Push-ups", TargetMuscleGroup = "Chest, Triceps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Hands elevated on bench, perform push-up motion." },
                new Exercise { Id = ExId_DeclinePushup, Name = "Decline Push-ups", TargetMuscleGroup = "Upper Chest, Triceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Feet elevated, hands on ground, perform push-up." },
                new Exercise { Id = ExId_DiamondPushup, Name = "Diamond Push-ups", TargetMuscleGroup = "Triceps, Inner Chest", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Hands together forming diamond shape, perform push-up." },
                new Exercise { Id = ExId_ChestPress, Name = "Dumbbell Chest Press", TargetMuscleGroup = "Chest, Triceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Lie on bench, press dumbbells up from chest level." },
                new Exercise { Id = ExId_ChestFly, Name = "Dumbbell Chest Fly", TargetMuscleGroup = "Chest", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Lie on bench, arc dumbbells out and back together." },
                new Exercise { Id = ExId_BenchPress, Name = "Barbell Bench Press", TargetMuscleGroup = "Chest, Triceps, Shoulders", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 3, Instructions = "Lower barbell to chest, press back to start position." },

                // Leg Exercises
                new Exercise { Id = ExId_Squat, Name = "Bodyweight Squats", TargetMuscleGroup = "Quads, Glutes, Hamstrings", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 2, Instructions = "Hips back and down, keep chest up, drive through heels." },
                new Exercise { Id = ExId_Lunge, Name = "Walking Lunges", TargetMuscleGroup = "Quads, Glutes", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 2, Instructions = "Step forward, lower back knee, alternate legs." },
                new Exercise { Id = ExId_BulgarianSplitSquat, Name = "Bulgarian Split Squat", TargetMuscleGroup = "Quads, Glutes", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Rear foot elevated, lower into single-leg squat." },
                new Exercise { Id = ExId_LegPress, Name = "Leg Press", TargetMuscleGroup = "Quads, Glutes", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Push platform away with feet, control descent." },
                new Exercise { Id = ExId_LegCurl, Name = "Leg Curl", TargetMuscleGroup = "Hamstrings", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Curl legs toward glutes, control return." },
                new Exercise { Id = ExId_CalfRaise, Name = "Calf Raises", TargetMuscleGroup = "Calves", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Rise onto toes, lower slowly." },
                new Exercise { Id = ExId_Deadlift, Name = "Barbell Deadlift", TargetMuscleGroup = "Back, Glutes, Hamstrings", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 4, Instructions = "Hinge at hips, lift bar by extending hips and knees." },
                new Exercise { Id = ExId_RomanianDeadlift, Name = "Romanian Deadlift", TargetMuscleGroup = "Hamstrings, Glutes", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Slight knee bend, hinge at hips, lower bar." },
                new Exercise { Id = ExId_GobletSquat, Name = "Goblet Squat", TargetMuscleGroup = "Quads, Glutes", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 2, Instructions = "Hold weight at chest, perform deep squat." },
                new Exercise { Id = ExId_WallSit, Name = "Wall Sit", TargetMuscleGroup = "Quads", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 0, Instructions = "Back against wall, thighs parallel to ground, hold." },

                // Back Exercises
                new Exercise { Id = ExId_DBRow, Name = "Dumbbell Rows", TargetMuscleGroup = "Back, Biceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Pull dumbbell to ribcage, control descent." },
                new Exercise { Id = ExId_BentOverRow, Name = "Bent Over Barbell Row", TargetMuscleGroup = "Back, Biceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Hinge forward, pull bar to lower chest." },
                new Exercise { Id = ExId_PullUp, Name = "Pull-ups", TargetMuscleGroup = "Back, Biceps", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 2, Instructions = "Hang from bar, pull chin over bar." },
                new Exercise { Id = ExId_LatPulldown, Name = "Lat Pulldown", TargetMuscleGroup = "Lats, Biceps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 2, Instructions = "Pull bar down to upper chest, control return." },
                new Exercise { Id = ExId_SeatedRow, Name = "Seated Cable Row", TargetMuscleGroup = "Back, Biceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Pull handle to torso, squeeze shoulder blades." },
                new Exercise { Id = ExId_TBarRow, Name = "T-Bar Row", TargetMuscleGroup = "Back, Biceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Pull weighted bar to chest, maintain neutral spine." },
                new Exercise { Id = ExId_SupermanHold, Name = "Superman Hold", TargetMuscleGroup = "Lower Back", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 0, Instructions = "Lie prone, lift arms and legs simultaneously, hold." },

                // Shoulder Exercises
                new Exercise { Id = ExId_ShoulderPress, Name = "Dumbbell Shoulder Press", TargetMuscleGroup = "Shoulders, Triceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Press dumbbells overhead from shoulder height." },
                new Exercise { Id = ExId_LateralRaise, Name = "Lateral Raises", TargetMuscleGroup = "Shoulders", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Raise arms out to sides to shoulder height." },
                new Exercise { Id = ExId_FrontRaise, Name = "Front Raises", TargetMuscleGroup = "Front Shoulders", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Raise arms forward to shoulder height." },
                new Exercise { Id = ExId_RearDeltFly, Name = "Rear Delt Flys", TargetMuscleGroup = "Rear Shoulders", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Bent over, raise arms out to sides." },
                new Exercise { Id = ExId_ArnoldPress, Name = "Arnold Press", TargetMuscleGroup = "Shoulders", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Rotate palms while pressing dumbbells overhead." },
                new Exercise { Id = ExId_Shrugs, Name = "Dumbbell Shrugs", TargetMuscleGroup = "Traps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Elevate shoulders toward ears, control descent." },

                // Arm Exercises
                new Exercise { Id = ExId_BicepCurl, Name = "Bicep Curls", TargetMuscleGroup = "Biceps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Curl dumbbells toward shoulders, control descent." },
                new Exercise { Id = ExId_HammerCurl, Name = "Hammer Curls", TargetMuscleGroup = "Biceps, Forearms", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Neutral grip curls, keep palms facing." },
                new Exercise { Id = ExId_TricepDip, Name = "Tricep Dips", TargetMuscleGroup = "Triceps, Chest", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Lower body by bending arms, push back up." },
                new Exercise { Id = ExId_TricepExtension, Name = "Overhead Tricep Extension", TargetMuscleGroup = "Triceps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Extend weight overhead, lower behind head." },
                new Exercise { Id = ExId_SkullCrusher, Name = "Skull Crushers", TargetMuscleGroup = "Triceps", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Lower bar to forehead, extend arms back up." },
                new Exercise { Id = ExId_ConcentrationCurl, Name = "Concentration Curls", TargetMuscleGroup = "Biceps", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Seated, curl one arm at a time with focus." },

                // Core Exercises
                new Exercise { Id = ExId_Plank, Name = "Plank Hold", TargetMuscleGroup = "Core", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 0, Instructions = "Hold plank position, maintain straight body line." },
                new Exercise { Id = ExId_SidePlank, Name = "Side Plank", TargetMuscleGroup = "Core, Obliques", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 0, Instructions = "Hold side position on forearm, keep hips elevated." },
                new Exercise { Id = ExId_Crunches, Name = "Crunches", TargetMuscleGroup = "Abs", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 0, Instructions = "Lift shoulders off ground, contract abs." },
                new Exercise { Id = ExId_BicycleCrunches, Name = "Bicycle Crunches", TargetMuscleGroup = "Abs, Obliques", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Alternate elbow to opposite knee in cycling motion." },
                new Exercise { Id = ExId_LegRaise, Name = "Leg Raises", TargetMuscleGroup = "Lower Abs", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Lie on back, raise legs to 90 degrees, lower slowly." },
                new Exercise { Id = ExId_RussianTwist, Name = "Russian Twists", TargetMuscleGroup = "Obliques", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Seated twist, rotate torso side to side." },
                new Exercise { Id = ExId_MountainClimber, Name = "Mountain Climbers", TargetMuscleGroup = "Core, Cardio", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 1, Instructions = "Plank position, alternate driving knees to chest." },
                new Exercise { Id = ExId_AbWheel, Name = "Ab Wheel Rollout", TargetMuscleGroup = "Core", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 2, Instructions = "Roll wheel forward, maintain core tension." },
                new Exercise { Id = ExId_HangingKneeRaise, Name = "Hanging Knee Raises", TargetMuscleGroup = "Lower Abs", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 2, Instructions = "Hang from bar, raise knees to chest." },

                // Cardio/HIIT Exercises
                new Exercise { Id = ExId_JumpingJack, Name = "Jumping Jacks", TargetMuscleGroup = "Full Body, Cardio", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 0, Instructions = "Jump while spreading legs and raising arms overhead." },
                new Exercise { Id = ExId_Burpee, Name = "Burpees", TargetMuscleGroup = "Full Body, Cardio", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Squat, plank, push-up, jump up explosively." },
                new Exercise { Id = ExId_HighKnees, Name = "High Knees", TargetMuscleGroup = "Cardio, Legs", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Run in place, drive knees high." },
                new Exercise { Id = ExId_ButtKicks, Name = "Butt Kicks", TargetMuscleGroup = "Cardio, Hamstrings", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Run in place, kick heels to glutes." },
                new Exercise { Id = ExId_JumpSquat, Name = "Jump Squats", TargetMuscleGroup = "Legs, Power", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Squat down, explode up into jump." },
                new Exercise { Id = ExId_BoxJump, Name = "Box Jumps", TargetMuscleGroup = "Legs, Power", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 3, Instructions = "Jump onto elevated platform, step down." },
                new Exercise { Id = ExId_JumpLunge, Name = "Jump Lunges", TargetMuscleGroup = "Legs, Power", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Lunge position, jump and switch legs mid-air." },
                new Exercise { Id = ExId_BearCrawl, Name = "Bear Crawls", TargetMuscleGroup = "Full Body", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 2, Instructions = "Crawl on hands and feet, keep hips low." },
                new Exercise { Id = ExId_SprintInterval, Name = "Sprint Intervals", TargetMuscleGroup = "Cardio, Legs", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 5, Instructions = "Maximum effort sprints with rest periods." },
                new Exercise { Id = ExId_RopeJump, Name = "Jump Rope", TargetMuscleGroup = "Cardio, Calves", Difficulty = DifficultyLevels.Beginner, EstimatedCaloriesPerRep = 1, Instructions = "Jump over rope with consistent rhythm." },

                // Functional/Olympic Exercises
                new Exercise { Id = ExId_KettlebellSwing, Name = "Kettlebell Swings", TargetMuscleGroup = "Glutes, Hamstrings, Core", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Hip hinge, swing kettlebell to shoulder height." },
                new Exercise { Id = ExId_CleanAndPress, Name = "Clean and Press", TargetMuscleGroup = "Full Body, Shoulders", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 4, Instructions = "Clean weight to shoulders, press overhead." },
                new Exercise { Id = ExId_TurkishGetUp, Name = "Turkish Get-Up", TargetMuscleGroup = "Full Body, Core", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 4, Instructions = "Stand from lying position while holding weight overhead." },
                new Exercise { Id = ExId_Thruster, Name = "Thrusters", TargetMuscleGroup = "Full Body", Difficulty = DifficultyLevels.Advanced, EstimatedCaloriesPerRep = 4, Instructions = "Squat with dumbbells, press overhead as you stand." },
                new Exercise { Id = ExId_WallBall, Name = "Wall Balls", TargetMuscleGroup = "Full Body", Difficulty = DifficultyLevels.Intermediate, EstimatedCaloriesPerRep = 3, Instructions = "Squat, throw medicine ball to target on wall." }
            };
        }

       // ==================== WORKOUT DEFINITIONS ====================
       public static IEnumerable<Workout> GetWorkouts()
    {
        return new List<Workout>
            {
                // Original Workouts
                new Workout {
                    Id = WkId_FullBody, Name = "Full Body Strength", Description = "A balanced workout hitting all major muscle groups.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 350,
                    Tags = "strength,full-body,intermediate"
                },
                new Workout {
                    Id = WkId_ChestFocus, Name = "Chest Builder", Description = "Focuses on building pectoral and tricep strength.",
                    Category = "chest", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 30, EstimatedCaloriesBurn = 300,
                    Tags = "strength,chest,advanced"
                },

                // Leg Workouts
                new Workout {
                    Id = WkId_LegDay, Name = "Ultimate Leg Day", Description = "Complete lower body workout for strength and size.",
                    Category = "legs", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 60, EstimatedCaloriesBurn = 450,
                    Tags = "strength,legs,mass-building,advanced"
                },
                new Workout {
                    Id = WkId_LegStrength, Name = "Leg Strength Builder", Description = "Focus on building raw leg power with compound movements.",
                    Category = "legs", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 50, EstimatedCaloriesBurn = 400,
                    Tags = "strength,legs,power,intermediate"
                },
                new Workout {
                    Id = WkId_LowerBodyPower, Name = "Lower Body Power", Description = "Explosive exercises for leg power and athleticism.",
                    Category = "legs", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 40, EstimatedCaloriesBurn = 380,
                    Tags = "power,legs,athletic,advanced"
                },

                // Back Workouts
                new Workout {
                    Id = WkId_BackAndBiceps, Name = "Back & Biceps Blast", Description = "Complete pulling workout for a strong, wide back.",
                    Category = "back", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 320,
                    Tags = "strength,back,biceps,pull,intermediate"
                },
                new Workout {
                    Id = WkId_UpperBodyPull, Name = "Upper Body Pull Day", Description = "All pulling movements for back and arm development.",
                    Category = "upper", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 50, EstimatedCaloriesBurn = 340,
                    Tags = "strength,pull,back,upper,intermediate"
                },
                new Workout {
                    Id = WkId_BodybuildingBack, Name = "Bodybuilding Back Day", Description = "High-volume back workout for muscle hypertrophy.",
                    Category = "back", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 55, EstimatedCaloriesBurn = 360,
                    Tags = "bodybuilding,back,hypertrophy,advanced"
                },

                // Shoulder Workouts
                new Workout {
                    Id = WkId_ShoulderBlaster, Name = "Shoulder Blaster", Description = "Comprehensive shoulder workout hitting all three deltoid heads.",
                    Category = "shoulders", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 35, EstimatedCaloriesBurn = 280,
                    Tags = "strength,shoulders,intermediate"
                },
                new Workout {
                    Id = WkId_BodybuildingShoulders, Name = "Bodybuilding Shoulders", Description = "High-volume shoulder workout for boulder shoulders.",
                    Category = "shoulders", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 45, EstimatedCaloriesBurn = 320,
                    Tags = "bodybuilding,shoulders,hypertrophy,advanced"
                },

                // Core Workouts
                new Workout {
                    Id = WkId_CoreCrusher, Name = "Core Crusher", Description = "Intense abdominal and core strengthening workout.",
                    Category = "core", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 25, EstimatedCaloriesBurn = 180,
                    Tags = "core,abs,strength,intermediate"
                },
                new Workout {
                    Id = WkId_CoreStability, Name = "Core Stability & Strength", Description = "Build a rock-solid core with isometric and dynamic movements.",
                    Category = "core", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 30, EstimatedCaloriesBurn = 200,
                    Tags = "core,stability,functional,advanced"
                },
                new Workout {
                    Id = WkId_QuickCore, Name = "Quick Core Burn", Description = "Fast-paced 15-minute core workout for busy schedules.",
                    Category = "core", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 15, EstimatedCaloriesBurn = 120,
                    Tags = "core,quick,beginner,home-workout"
                },

                // Cardio & HIIT Workouts
                new Workout {
                    Id = WkId_HIITCardio, Name = "HIIT Cardio Blast", Description = "High-intensity interval training for maximum calorie burn.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 25, EstimatedCaloriesBurn = 300,
                    Tags = "hiit,cardio,fat-loss,intermediate"
                },
                new Workout {
                    Id = WkId_AdvancedHIIT, Name = "Advanced HIIT Protocol", Description = "Brutal high-intensity workout for experienced athletes.",
                    Category = "cardio", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 30, EstimatedCaloriesBurn = 400,
                    Tags = "hiit,cardio,advanced,fat-loss"
                },
                new Workout {
                    Id = WkId_BeginnerCardio, Name = "Beginner Cardio Starter", Description = "Gentle cardio introduction for fitness beginners.",
                    Category = "cardio", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 20, EstimatedCaloriesBurn = 150,
                    Tags = "cardio,beginner,low-impact"
                },
                new Workout {
                    Id = WkId_20MinHIIT, Name = "20-Minute HIIT", Description = "Quick but effective HIIT session for busy days.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 20, EstimatedCaloriesBurn = 250,
                    Tags = "hiit,quick,cardio,intermediate"
                },

                // Full Body Workouts
                new Workout {
                    Id = WkId_BeginnerFullBody, Name = "Beginner Full Body", Description = "Perfect starting point for fitness newcomers.",
                    Category = "full-body", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 30, EstimatedCaloriesBurn = 200,
                    Tags = "full-body,beginner,strength"
                },
                new Workout {
                    Id = WkId_TotalBodyConditioning, Name = "Total Body Conditioning", Description = "Complete conditioning workout for overall fitness.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 360,
                    Tags = "full-body,conditioning,intermediate"
                },
                new Workout {
                    Id = WkId_30MinFullBody, Name = "30-Minute Full Body Blast", Description = "Efficient full body workout in just 30 minutes.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 30, EstimatedCaloriesBurn = 280,
                    Tags = "full-body,quick,intermediate"
                },
                new Workout {
                    Id = WkId_CompoundMovements, Name = "Compound Movements Focus", Description = "Build strength with multi-joint compound exercises.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 50, EstimatedCaloriesBurn = 420,
                    Tags = "full-body,compound,strength,advanced"
                },

                // Upper Body Workouts
                new Workout {
                    Id = WkId_UpperBodyPush, Name = "Upper Body Push Day", Description = "All pushing movements for chest, shoulders, and triceps.",
                    Category = "upper", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 320,
                    Tags = "push,upper,strength,intermediate"
                },
                new Workout {
                    Id = WkId_ChestAndBack, Name = "Chest & Back Superset", Description = "Antagonistic training for upper body development.",
                    Category = "upper", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 55, EstimatedCaloriesBurn = 380,
                    Tags = "upper,superset,strength,advanced"
                },
                new Workout {
                    Id = WkId_BodybuildingChest, Name = "Bodybuilding Chest Day", Description = "High-volume chest workout for maximum muscle growth.",
                    Category = "chest", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 50, EstimatedCaloriesBurn = 350,
                    Tags = "bodybuilding,chest,hypertrophy,advanced"
                },

                // Arms Workouts
                new Workout {
                    Id = WkId_ArmsAndAbs, Name = "Arms & Abs Finisher", Description = "Targeted arm and core workout.",
                    Category = "arms", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 30, EstimatedCaloriesBurn = 220,
                    Tags = "arms,abs,beginner"
                },
                new Workout {
                    Id = WkId_BodybuildingArms, Name = "Bodybuilding Arms", Description = "Complete arm workout for bicep and tricep development.",
                    Category = "arms", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 40, EstimatedCaloriesBurn = 260,
                    Tags = "bodybuilding,arms,hypertrophy,intermediate"
                },

                // Specialized Workouts
                new Workout {
                    Id = WkId_AtHomeBodyweight, Name = "At-Home Bodyweight Workout", Description = "No equipment needed for this effective home workout.",
                    Category = "full-body", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 35, EstimatedCaloriesBurn = 240,
                    Tags = "home-workout,bodyweight,full-body,beginner"
                },
                new Workout {
                    Id = WkId_QuickMorning, Name = "Quick Morning Energizer", Description = "Wake up your body with this energizing routine.",
                    Category = "full-body", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 15, EstimatedCaloriesBurn = 120,
                    Tags = "quick,morning,beginner,energy"
                },
                new Workout {
                    Id = WkId_StrengthBuilder, Name = "Strength Builder", Description = "Progressive overload workout for building raw strength.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 60, EstimatedCaloriesBurn = 400,
                    Tags = "strength,progressive-overload,advanced"
                },
                new Workout {
                    Id = WkId_FatBurner, Name = "Fat Burner Circuit", Description = "Circuit training designed to maximize calorie burn.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 35, EstimatedCaloriesBurn = 380,
                    Tags = "circuit,fat-loss,cardio,intermediate"
                },
                new Workout {
                    Id = WkId_PushPull, Name = "Push/Pull Split", Description = "Classic push-pull training split for balanced development.",
                    Category = "upper", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 50, EstimatedCaloriesBurn = 340,
                    Tags = "push-pull,upper,split,intermediate"
                },
                new Workout {
                    Id = WkId_PowerlifterBasics, Name = "Powerlifter Basics", Description = "Focus on the big three: squat, bench, deadlift.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 70, EstimatedCaloriesBurn = 450,
                    Tags = "powerlifting,strength,advanced,compound"
                },
                new Workout {
                    Id = WkId_FunctionalFitness, Name = "Functional Fitness", Description = "Real-world movements for everyday strength and mobility.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 40, EstimatedCaloriesBurn = 300,
                    Tags = "functional,full-body,mobility,intermediate"
                },
                new Workout {
                    Id = WkId_AthleticPerformance, Name = "Athletic Performance", Description = "Train like an athlete with explosive and dynamic movements.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 50, EstimatedCaloriesBurn = 420,
                    Tags = "athletic,performance,explosive,advanced"
                },
                new Workout {
                    Id = WkId_MobilityAndStrength, Name = "Mobility & Strength", Description = "Combine flexibility work with strength training.",
                    Category = "full-body", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 40, EstimatedCaloriesBurn = 220,
                    Tags = "mobility,strength,flexibility,beginner"
                },
                new Workout {
                    Id = WkId_BodybuildingLegs, Name = "Bodybuilding Legs", Description = "High-volume leg day for maximum hypertrophy.",
                    Category = "legs", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 65, EstimatedCaloriesBurn = 480,
                    Tags = "bodybuilding,legs,hypertrophy,advanced"
                },
                new Workout {
                    Id = WkId_CrossTraining, Name = "Cross Training Workout", Description = "Varied exercises for complete fitness development.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 350,
                    Tags = "cross-training,full-body,varied,intermediate"
                },
                new Workout {
                    Id = WkId_MetabolicConditioning, Name = "Metabolic Conditioning", Description = "High-intensity metabolic workout for fat loss.",
                    Category = "cardio", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 30, EstimatedCaloriesBurn = 380,
                    Tags = "metabolic,conditioning,fat-loss,advanced"
                },
                new Workout {
                    Id = WkId_ExplosivePower, Name = "Explosive Power Training", Description = "Develop explosive strength with plyometric exercises.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 40, EstimatedCaloriesBurn = 360,
                    Tags = "explosive,power,plyometric,advanced"
                },
                new Workout {
                    Id = WkId_Endurance, Name = "Endurance Builder", Description = "Build muscular and cardiovascular endurance.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 50, EstimatedCaloriesBurn = 400,
                    Tags = "endurance,cardio,stamina,intermediate"
                },
                new Workout {
                    Id = WkId_RecoveryDay, Name = "Active Recovery", Description = "Light movement for recovery and mobility.",
                    Category = "recovery", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 25, EstimatedCaloriesBurn = 100,
                    Tags = "recovery,mobility,light,beginner"
                },
                new Workout {
                    Id = WkId_UpperLowerSplit, Name = "Upper/Lower Split", Description = "Classic training split alternating upper and lower body.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 50, EstimatedCaloriesBurn = 360,
                    Tags = "split,upper-lower,intermediate"
                },
                new Workout {
                    Id = WkId_IsolationWork, Name = "Isolation Work", Description = "Target specific muscles with isolation exercises.",
                    Category = "upper", Difficulty = DifficultyLevels.Beginner, DurationMinutes = 35, EstimatedCaloriesBurn = 220,
                    Tags = "isolation,hypertrophy,beginner"
                },
                new Workout {
                    Id = WkId_CardioCore, Name = "Cardio Core Combo", Description = "Combine cardio intervals with core strengthening.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 30, EstimatedCaloriesBurn = 280,
                    Tags = "cardio,core,combo,intermediate"
                },
                new Workout {
                    Id = WkId_StrengthEndurance, Name = "Strength Endurance", Description = "Build both strength and endurance simultaneously.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 340,
                    Tags = "strength,endurance,hybrid,intermediate"
                },
                new Workout {
                    Id = WkId_PlyometricPower, Name = "Plyometric Power", Description = "Jump training for explosive athletic power.",
                    Category = "legs", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 35, EstimatedCaloriesBurn = 320,
                    Tags = "plyometric,power,explosive,advanced"
                },
                new Workout {
                    Id = WkId_CircuitTraining, Name = "Circuit Training", Description = "Non-stop circuit for full-body conditioning.",
                    Category = "full-body", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 40, EstimatedCaloriesBurn = 360,
                    Tags = "circuit,full-body,conditioning,intermediate"
                },
                new Workout {
                    Id = WkId_AdvancedAthlete, Name = "Advanced Athlete Program", Description = "Elite-level training for serious athletes.",
                    Category = "full-body", Difficulty = DifficultyLevels.Advanced, DurationMinutes = 75, EstimatedCaloriesBurn = 500,
                    Tags = "advanced,athlete,elite,performance"
                },
                new Workout {
                    Id = WkId_WeightLossSpecial, Name = "Weight Loss Special", Description = "Optimized workout program for maximum fat loss.",
                    Category = "cardio", Difficulty = DifficultyLevels.Intermediate, DurationMinutes = 45, EstimatedCaloriesBurn = 450,
                    Tags = "weight-loss,fat-loss,cardio,intermediate"
                }
        };

   }



       // ==================== WORKOUT-EXERCISE RELATIONSHIPS ====================
       public static IEnumerable<WorkoutExercise> GetWorkoutExercises()
    {
        return new List<WorkoutExercise>
            {
                // ===== Full Body Strength (Original) =====
                new WorkoutExercise { WorkoutId = WkId_FullBody, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 1, Reps = "30 seconds", RestTimeSeconds = 15, Instructions = "Light pace, get blood flowing." },
                new WorkoutExercise { WorkoutId = WkId_FullBody, ExerciseId = ExId_Squat, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_FullBody, ExerciseId = ExId_Pushup, Order = 3, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_FullBody, ExerciseId = ExId_DBRow, Order = 4, Sets = 3, Reps = "12 per side", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_FullBody, ExerciseId = ExId_Plank, Order = 5, Sets = 2, Reps = "45 seconds", RestTimeSeconds = 45 },
                
                // ===== Chest Builder (Original) =====
                new WorkoutExercise { WorkoutId = WkId_ChestFocus, ExerciseId = ExId_Pushup, Order = 1, Sets = 4, Reps = "To Failure", RestTimeSeconds = 90, Instructions = "Perform as many as possible (AMRAP)." },
                new WorkoutExercise { WorkoutId = WkId_ChestFocus, ExerciseId = ExId_DBRow, Order = 2, Sets = 3, Reps = "10 per arm", RestTimeSeconds = 60, Instructions = "Use heavy weight." },

                // ===== Ultimate Leg Day =====
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 1, Reps = "60 seconds", RestTimeSeconds = 30, Instructions = "Warm up thoroughly." },
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_Squat, Order = 2, Sets = 4, Reps = "12", RestTimeSeconds = 90, Instructions = "Go deep, maintain form." },
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_Deadlift, Order = 3, Sets = 4, Reps = "8", RestTimeSeconds = 120, Instructions = "Heavy weight, perfect form." },
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_Lunge, Order = 4, Sets = 3, Reps = "10 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_LegCurl, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_LegDay, ExerciseId = ExId_CalfRaise, Order = 6, Sets = 4, Reps = "20", RestTimeSeconds = 30 },

                // ===== Back & Biceps Blast =====
                //new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_BandPull, Order = 1, Sets = 2, Reps = "15", RestTimeSeconds = 30, Instructions = "Light resistance, warm up shoulders." },
                new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_PullUp, Order = 2, Sets = 4, Reps = "8-10", RestTimeSeconds = 90, Instructions = "Use assistance if needed." },
                new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_BentOverRow, Order = 3, Sets = 4, Reps = "10", RestTimeSeconds = 75 },
                new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_DBRow, Order = 4, Sets = 3, Reps = "12 per arm", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_BicepCurl, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BackAndBiceps, ExerciseId = ExId_HammerCurl, Order = 6, Sets = 3, Reps = "12", RestTimeSeconds = 45 },

                // ===== Shoulder Blaster =====
                new WorkoutExercise { WorkoutId = WkId_ShoulderBlaster, ExerciseId = ExId_ShoulderPress, Order = 1, Sets = 4, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_ShoulderBlaster, ExerciseId = ExId_LateralRaise, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_ShoulderBlaster, ExerciseId = ExId_FrontRaise, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_ShoulderBlaster, ExerciseId = ExId_RearDeltFly, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_ShoulderBlaster, ExerciseId = ExId_Shrugs, Order = 5, Sets = 3, Reps = "20", RestTimeSeconds = 30 },

                // ===== Core Crusher =====
                new WorkoutExercise { WorkoutId = WkId_CoreCrusher, ExerciseId = ExId_Plank, Order = 1, Sets = 3, Reps = "60 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CoreCrusher, ExerciseId = ExId_BicycleCrunches, Order = 2, Sets = 3, Reps = "20", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CoreCrusher, ExerciseId = ExId_LegRaise, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_CoreCrusher, ExerciseId = ExId_RussianTwist, Order = 4, Sets = 3, Reps = "30", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CoreCrusher, ExerciseId = ExId_MountainClimber, Order = 5, Sets = 3, Reps = "20", RestTimeSeconds = 30 },

                // ===== HIIT Cardio Blast =====
                new WorkoutExercise { WorkoutId = WkId_HIITCardio, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 1, Reps = "30 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_HIITCardio, ExerciseId = ExId_Burpee, Order = 2, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30, Instructions = "All-out effort." },
                new WorkoutExercise { WorkoutId = WkId_HIITCardio, ExerciseId = ExId_HighKnees, Order = 3, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_HIITCardio, ExerciseId = ExId_JumpSquat, Order = 4, Sets = 4, Reps = "20 seconds", RestTimeSeconds = 40 },
                new WorkoutExercise { WorkoutId = WkId_HIITCardio, ExerciseId = ExId_MountainClimber, Order = 5, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },

                // ===== Beginner Full Body =====
                new WorkoutExercise { WorkoutId = WkId_BeginnerFullBody, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 1, Reps = "30 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerFullBody, ExerciseId = ExId_Squat, Order = 2, Sets = 3, Reps = "10", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerFullBody, ExerciseId = ExId_InclinePushup, Order = 3, Sets = 3, Reps = "8", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerFullBody, ExerciseId = ExId_DBRow, Order = 4, Sets = 3, Reps = "10 per arm", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerFullBody, ExerciseId = ExId_Plank, Order = 5, Sets = 2, Reps = "30 seconds", RestTimeSeconds = 30 },

                // ===== Upper Body Push Day =====
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPush, ExerciseId = ExId_BenchPress, Order = 1, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPush, ExerciseId = ExId_ChestPress, Order = 2, Sets = 3, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPush, ExerciseId = ExId_ShoulderPress, Order = 3, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPush, ExerciseId = ExId_TricepDip, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPush, ExerciseId = ExId_LateralRaise, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },

                // ===== Upper Body Pull Day =====
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPull, ExerciseId = ExId_Deadlift, Order = 1, Sets = 4, Reps = "6", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPull, ExerciseId = ExId_PullUp, Order = 2, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPull, ExerciseId = ExId_BentOverRow, Order = 3, Sets = 4, Reps = "10", RestTimeSeconds = 75 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPull, ExerciseId = ExId_SeatedRow, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_UpperBodyPull, ExerciseId = ExId_BicepCurl, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 45 },

                // ===== Lower Body Power =====
                new WorkoutExercise { WorkoutId = WkId_LowerBodyPower, ExerciseId = ExId_JumpSquat, Order = 1, Sets = 4, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_LowerBodyPower, ExerciseId = ExId_BoxJump, Order = 2, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_LowerBodyPower, ExerciseId = ExId_JumpLunge, Order = 3, Sets = 3, Reps = "8 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_LowerBodyPower, ExerciseId = ExId_Deadlift, Order = 4, Sets = 3, Reps = "5", RestTimeSeconds = 120, Instructions = "Explosive lift, controlled descent." },
                new WorkoutExercise { WorkoutId = WkId_LowerBodyPower, ExerciseId = ExId_KettlebellSwing, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },

                // ===== Arms & Abs Finisher =====
                new WorkoutExercise { WorkoutId = WkId_ArmsAndAbs, ExerciseId = ExId_BicepCurl, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_ArmsAndAbs, ExerciseId = ExId_TricepExtension, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_ArmsAndAbs, ExerciseId = ExId_HammerCurl, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_ArmsAndAbs, ExerciseId = ExId_Crunches, Order = 4, Sets = 3, Reps = "20", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_ArmsAndAbs, ExerciseId = ExId_Plank, Order = 5, Sets = 2, Reps = "45 seconds", RestTimeSeconds = 30 },

                // ===== Quick Morning Energizer =====
                new WorkoutExercise { WorkoutId = WkId_QuickMorning, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 2, Reps = "30 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_QuickMorning, ExerciseId = ExId_Squat, Order = 2, Sets = 2, Reps = "10", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_QuickMorning, ExerciseId = ExId_Pushup, Order = 3, Sets = 2, Reps = "8", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_QuickMorning, ExerciseId = ExId_MountainClimber, Order = 4, Sets = 2, Reps = "15", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_QuickMorning, ExerciseId = ExId_Plank, Order = 5, Sets = 1, Reps = "30 seconds", RestTimeSeconds = 0 },

                // ===== At-Home Bodyweight Workout =====
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 1, Reps = "45 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_Squat, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_Pushup, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_Lunge, Order = 4, Sets = 3, Reps = "10 per leg", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_Plank, Order = 5, Sets = 2, Reps = "45 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AtHomeBodyweight, ExerciseId = ExId_BicycleCrunches, Order = 6, Sets = 2, Reps = "20", RestTimeSeconds = 30 },

                // ===== Advanced HIIT Protocol =====
                new WorkoutExercise { WorkoutId = WkId_AdvancedHIIT, ExerciseId = ExId_Burpee, Order = 1, Sets = 5, Reps = "40 seconds", RestTimeSeconds = 20, Instructions = "Maximum effort!" },
                new WorkoutExercise { WorkoutId = WkId_AdvancedHIIT, ExerciseId = ExId_JumpSquat, Order = 2, Sets = 5, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedHIIT, ExerciseId = ExId_MountainClimber, Order = 3, Sets = 5, Reps = "40 seconds", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedHIIT, ExerciseId = ExId_BoxJump, Order = 4, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedHIIT, ExerciseId = ExId_SprintInterval, Order = 5, Sets = 6, Reps = "20 seconds", RestTimeSeconds = 40 },

                // ===== Strength Builder =====
                new WorkoutExercise { WorkoutId = WkId_StrengthBuilder, ExerciseId = ExId_Deadlift, Order = 1, Sets = 5, Reps = "5", RestTimeSeconds = 180, Instructions = "Heavy weight, perfect form." },
                new WorkoutExercise { WorkoutId = WkId_StrengthBuilder, ExerciseId = ExId_BenchPress, Order = 2, Sets = 5, Reps = "5", RestTimeSeconds = 180 },
                new WorkoutExercise { WorkoutId = WkId_StrengthBuilder, ExerciseId = ExId_Squat, Order = 3, Sets = 5, Reps = "5", RestTimeSeconds = 180 },
                new WorkoutExercise { WorkoutId = WkId_StrengthBuilder, ExerciseId = ExId_BentOverRow, Order = 4, Sets = 4, Reps = "6", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_StrengthBuilder, ExerciseId = ExId_ShoulderPress, Order = 5, Sets = 4, Reps = "6", RestTimeSeconds = 120 },

                // ===== Fat Burner Circuit =====
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_Burpee, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_JumpSquat, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_MountainClimber, Order = 3, Sets = 3, Reps = "20", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_HighKnees, Order = 4, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_JumpLunge, Order = 5, Sets = 3, Reps = "12 per leg", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_FatBurner, ExerciseId = ExId_Plank, Order = 6, Sets = 2, Reps = "45 seconds", RestTimeSeconds = 20 },

                // ===== Leg Strength Builder =====
                new WorkoutExercise { WorkoutId = WkId_LegStrength, ExerciseId = ExId_Squat, Order = 1, Sets = 5, Reps = "8", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_LegStrength, ExerciseId = ExId_RomanianDeadlift, Order = 2, Sets = 4, Reps = "10", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_LegStrength, ExerciseId = ExId_BulgarianSplitSquat, Order = 3, Sets = 3, Reps = "10 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_LegStrength, ExerciseId = ExId_LegPress, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_LegStrength, ExerciseId = ExId_CalfRaise, Order = 5, Sets = 4, Reps = "15", RestTimeSeconds = 30 },

                // ===== Chest & Back Superset =====
                new WorkoutExercise { WorkoutId = WkId_ChestAndBack, ExerciseId = ExId_BenchPress, Order = 1, Sets = 4, Reps = "8", RestTimeSeconds = 60, Instructions = "Superset with next exercise." },
                new WorkoutExercise { WorkoutId = WkId_ChestAndBack, ExerciseId = ExId_BentOverRow, Order = 2, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_ChestAndBack, ExerciseId = ExId_ChestFly, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_ChestAndBack, ExerciseId = ExId_LatPulldown, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_ChestAndBack, ExerciseId = ExId_Pushup, Order = 5, Sets = 2, Reps = "To Failure", RestTimeSeconds = 60 },

                // ===== Total Body Conditioning =====
                new WorkoutExercise { WorkoutId = WkId_TotalBodyConditioning, ExerciseId = ExId_KettlebellSwing, Order = 1, Sets = 3, Reps = "20", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_TotalBodyConditioning, ExerciseId = ExId_Thruster, Order = 2, Sets = 3, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_TotalBodyConditioning, ExerciseId = ExId_Burpee, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_TotalBodyConditioning, ExerciseId = ExId_DBRow, Order = 4, Sets = 3, Reps = "12 per arm", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_TotalBodyConditioning, ExerciseId = ExId_Plank, Order = 5, Sets = 3, Reps = "60 seconds", RestTimeSeconds = 30 },

                // ===== Core Stability & Strength =====
                new WorkoutExercise { WorkoutId = WkId_CoreStability, ExerciseId = ExId_Plank, Order = 1, Sets = 3, Reps = "90 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CoreStability, ExerciseId = ExId_SidePlank, Order = 2, Sets = 3, Reps = "60 seconds per side", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CoreStability, ExerciseId = ExId_AbWheel, Order = 3, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_CoreStability, ExerciseId = ExId_HangingKneeRaise, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_CoreStability, ExerciseId = ExId_RussianTwist, Order = 5, Sets = 3, Reps = "40", RestTimeSeconds = 30 },

                // ===== Beginner Cardio Starter =====
                new WorkoutExercise { WorkoutId = WkId_BeginnerCardio, ExerciseId = ExId_JumpingJack, Order = 1, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerCardio, ExerciseId = ExId_HighKnees, Order = 2, Sets = 3, Reps = "20 seconds", RestTimeSeconds = 40 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerCardio, ExerciseId = ExId_ButtKicks, Order = 3, Sets = 3, Reps = "20 seconds", RestTimeSeconds = 40 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerCardio, ExerciseId = ExId_MountainClimber, Order = 4, Sets = 2, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BeginnerCardio, ExerciseId = ExId_RopeJump, Order = 5, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 30 },

                // ===== Powerlifter Basics =====
                new WorkoutExercise { WorkoutId = WkId_PowerlifterBasics, ExerciseId = ExId_Squat, Order = 1, Sets = 5, Reps = "3", RestTimeSeconds = 240, Instructions = "Maximum weight, perfect form." },
                new WorkoutExercise { WorkoutId = WkId_PowerlifterBasics, ExerciseId = ExId_BenchPress, Order = 2, Sets = 5, Reps = "3", RestTimeSeconds = 240 },
                new WorkoutExercise { WorkoutId = WkId_PowerlifterBasics, ExerciseId = ExId_Deadlift, Order = 3, Sets = 5, Reps = "3", RestTimeSeconds = 240 },
                new WorkoutExercise { WorkoutId = WkId_PowerlifterBasics, ExerciseId = ExId_BentOverRow, Order = 4, Sets = 3, Reps = "5", RestTimeSeconds = 120, Instructions = "Accessory work." },

                // ===== Functional Fitness =====
                new WorkoutExercise { WorkoutId = WkId_FunctionalFitness, ExerciseId = ExId_KettlebellSwing, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_FunctionalFitness, ExerciseId = ExId_TurkishGetUp, Order = 2, Sets = 3, Reps = "5 per side", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_FunctionalFitness, ExerciseId = ExId_GobletSquat, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_FunctionalFitness, ExerciseId = ExId_BearCrawl, Order = 4, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_FunctionalFitness, ExerciseId = ExId_WallBall, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },

                // ===== Athletic Performance =====
                new WorkoutExercise { WorkoutId = WkId_AthleticPerformance, ExerciseId = ExId_BoxJump, Order = 1, Sets = 4, Reps = "8", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_AthleticPerformance, ExerciseId = ExId_CleanAndPress, Order = 2, Sets = 4, Reps = "6", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_AthleticPerformance, ExerciseId = ExId_JumpSquat, Order = 3, Sets = 4, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_AthleticPerformance, ExerciseId = ExId_SprintInterval, Order = 4, Sets = 6, Reps = "30 seconds", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_AthleticPerformance, ExerciseId = ExId_BearCrawl, Order = 5, Sets = 3, Reps = "40 seconds", RestTimeSeconds = 45 },

                // ===== Mobility & Strength =====
                new WorkoutExercise { WorkoutId = WkId_MobilityAndStrength, ExerciseId = ExId_GobletSquat, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 30, Instructions = "Focus on depth and mobility." },
                new WorkoutExercise { WorkoutId = WkId_MobilityAndStrength, ExerciseId = ExId_TurkishGetUp, Order = 2, Sets = 2, Reps = "5 per side", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_MobilityAndStrength, ExerciseId = ExId_Lunge, Order = 3, Sets = 3, Reps = "12 per leg", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_MobilityAndStrength, ExerciseId = ExId_SupermanHold, Order = 4, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_MobilityAndStrength, ExerciseId = ExId_WallSit, Order = 5, Sets = 3, Reps = "45 seconds", RestTimeSeconds = 30 },

                // ===== Bodybuilding Chest Day =====
                new WorkoutExercise { WorkoutId = WkId_BodybuildingChest, ExerciseId = ExId_BenchPress, Order = 1, Sets = 4, Reps = "10", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingChest, ExerciseId = ExId_ChestPress, Order = 2, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingChest, ExerciseId = ExId_ChestFly, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingChest, ExerciseId = ExId_DeclinePushup, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingChest, ExerciseId = ExId_DiamondPushup, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 45 },

                // ===== Bodybuilding Back Day =====
                new WorkoutExercise { WorkoutId = WkId_BodybuildingBack, ExerciseId = ExId_Deadlift, Order = 1, Sets = 4, Reps = "8", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingBack, ExerciseId = ExId_PullUp, Order = 2, Sets = 4, Reps = "10", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingBack, ExerciseId = ExId_TBarRow, Order = 3, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingBack, ExerciseId = ExId_SeatedRow, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingBack, ExerciseId = ExId_LatPulldown, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },

                // ===== Bodybuilding Legs Day =====
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_Squat, Order = 1, Sets = 5, Reps = "10", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_LegPress, Order = 2, Sets = 4, Reps = "15", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_RomanianDeadlift, Order = 3, Sets = 4, Reps = "12", RestTimeSeconds = 75 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_BulgarianSplitSquat, Order = 4, Sets = 3, Reps = "12 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_LegCurl, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingLegs, ExerciseId = ExId_CalfRaise, Order = 6, Sets = 4, Reps = "20", RestTimeSeconds = 30 },

                // ===== Bodybuilding Shoulders Day =====
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_ShoulderPress, Order = 1, Sets = 4, Reps = "10", RestTimeSeconds = 75 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_ArnoldPress, Order = 2, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_LateralRaise, Order = 3, Sets = 4, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_FrontRaise, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_RearDeltFly, Order = 5, Sets = 4, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingShoulders, ExerciseId = ExId_Shrugs, Order = 6, Sets = 3, Reps = "20", RestTimeSeconds = 30 },

                // ===== Bodybuilding Arms Day =====
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_BicepCurl, Order = 1, Sets = 4, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_TricepDip, Order = 2, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_HammerCurl, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_SkullCrusher, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_ConcentrationCurl, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_BodybuildingArms, ExerciseId = ExId_TricepExtension, Order = 6, Sets = 3, Reps = "15", RestTimeSeconds = 30 },

                // ===== Cross Training Workout =====
                new WorkoutExercise { WorkoutId = WkId_CrossTraining, ExerciseId = ExId_KettlebellSwing, Order = 1, Sets = 3, Reps = "20", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_CrossTraining, ExerciseId = ExId_BoxJump, Order = 2, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_CrossTraining, ExerciseId = ExId_Thruster, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_CrossTraining, ExerciseId = ExId_PullUp, Order = 4, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_CrossTraining, ExerciseId = ExId_Burpee, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 45 },

                // ===== Metabolic Conditioning =====
                new WorkoutExercise { WorkoutId = WkId_MetabolicConditioning, ExerciseId = ExId_Burpee, Order = 1, Sets = 5, Reps = "12", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_MetabolicConditioning, ExerciseId = ExId_KettlebellSwing, Order = 2, Sets = 5, Reps = "20", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_MetabolicConditioning, ExerciseId = ExId_JumpSquat, Order = 3, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_MetabolicConditioning, ExerciseId = ExId_MountainClimber, Order = 4, Sets = 4, Reps = "30", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_MetabolicConditioning, ExerciseId = ExId_Thruster, Order = 5, Sets = 4, Reps = "12", RestTimeSeconds = 30 },

                // ===== Explosive Power Training =====
                new WorkoutExercise { WorkoutId = WkId_ExplosivePower, ExerciseId = ExId_BoxJump, Order = 1, Sets = 5, Reps = "6", RestTimeSeconds = 90, Instructions = "Max height, focus on explosiveness." },
                new WorkoutExercise { WorkoutId = WkId_ExplosivePower, ExerciseId = ExId_CleanAndPress, Order = 2, Sets = 4, Reps = "5", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_ExplosivePower, ExerciseId = ExId_JumpSquat, Order = 3, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_ExplosivePower, ExerciseId = ExId_JumpLunge, Order = 4, Sets = 3, Reps = "6 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_ExplosivePower, ExerciseId = ExId_KettlebellSwing, Order = 5, Sets = 3, Reps = "15", RestTimeSeconds = 45 },

                // ===== Endurance Builder =====
                new WorkoutExercise { WorkoutId = WkId_Endurance, ExerciseId = ExId_RopeJump, Order = 1, Sets = 5, Reps = "2 minutes", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_Endurance, ExerciseId = ExId_Squat, Order = 2, Sets = 4, Reps = "20", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_Endurance, ExerciseId = ExId_Pushup, Order = 3, Sets = 4, Reps = "20", RestTimeSeconds = 30 },
                //new WorkoutExercise { WorkoutId = WkId_Endurance, ExerciseId = ExId_BurpeeOrder = 4, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_Endurance, ExerciseId = ExId_MountainClimber, Order = 5, Sets = 4, Reps = "30", RestTimeSeconds = 20 },

                // ===== Active Recovery =====
                new WorkoutExercise { WorkoutId = WkId_RecoveryDay, ExerciseId = ExId_WallSit, Order = 1, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 30, Instructions = "Light intensity, focus on form." },
                new WorkoutExercise { WorkoutId = WkId_RecoveryDay, ExerciseId = ExId_Plank, Order = 2, Sets = 2, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_RecoveryDay, ExerciseId = ExId_SupermanHold, Order = 3, Sets = 2, Reps = "20 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_RecoveryDay, ExerciseId = ExId_InclinePushup, Order = 4, Sets = 2, Reps = "10", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_RecoveryDay, ExerciseId = ExId_JumpingJack, Order = 5, Sets = 2, Reps = "30 seconds", RestTimeSeconds = 20 },

                // ===== 30-Minute Full Body Blast =====
                new WorkoutExercise { WorkoutId = WkId_30MinFullBody, ExerciseId = ExId_Squat, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_30MinFullBody, ExerciseId = ExId_Pushup, Order = 2, Sets = 3, Reps = "12", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_30MinFullBody, ExerciseId = ExId_DBRow, Order = 3, Sets = 3, Reps = "12 per arm", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_30MinFullBody, ExerciseId = ExId_Lunge, Order = 4, Sets = 3, Reps = "10 per leg", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_30MinFullBody, ExerciseId = ExId_Plank, Order = 5, Sets = 2, Reps = "45 seconds", RestTimeSeconds = 30 },

                // ===== 20-Minute HIIT =====
                new WorkoutExercise { WorkoutId = WkId_20MinHIIT, ExerciseId = ExId_Burpee, Order = 1, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_20MinHIIT, ExerciseId = ExId_JumpSquat, Order = 2, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_20MinHIIT, ExerciseId = ExId_MountainClimber, Order = 3, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_20MinHIIT, ExerciseId = ExId_HighKnees, Order = 4, Sets = 4, Reps = "30 seconds", RestTimeSeconds = 30 },

                // ===== Quick Core Burn =====
                new WorkoutExercise { WorkoutId = WkId_QuickCore, ExerciseId = ExId_Plank, Order = 1, Sets = 3, Reps = "45 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_QuickCore, ExerciseId = ExId_BicycleCrunches, Order = 2, Sets = 3, Reps = "20", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_QuickCore, ExerciseId = ExId_LegRaise, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_QuickCore, ExerciseId = ExId_RussianTwist, Order = 4, Sets = 2, Reps = "30", RestTimeSeconds = 15 },

                // ===== Upper/Lower Split =====
                new WorkoutExercise { WorkoutId = WkId_UpperLowerSplit, ExerciseId = ExId_BenchPress, Order = 1, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_UpperLowerSplit, ExerciseId = ExId_BentOverRow, Order = 2, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_UpperLowerSplit, ExerciseId = ExId_ShoulderPress, Order = 3, Sets = 3, Reps = "10", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_UpperLowerSplit, ExerciseId = ExId_BicepCurl, Order = 4, Sets = 3, Reps = "12", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_UpperLowerSplit, ExerciseId = ExId_TricepDip, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 45 },

                // ===== Compound Movements Focus =====
                new WorkoutExercise { WorkoutId = WkId_CompoundMovements, ExerciseId = ExId_Deadlift, Order = 1, Sets = 5, Reps = "5", RestTimeSeconds = 180 },
                new WorkoutExercise { WorkoutId = WkId_CompoundMovements, ExerciseId = ExId_Squat, Order = 2, Sets = 5, Reps = "5", RestTimeSeconds = 180 },
                new WorkoutExercise { WorkoutId = WkId_CompoundMovements, ExerciseId = ExId_BenchPress, Order = 3, Sets = 5, Reps = "5", RestTimeSeconds = 180 },
                new WorkoutExercise { WorkoutId = WkId_CompoundMovements, ExerciseId = ExId_BentOverRow, Order = 4, Sets = 4, Reps = "8", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_CompoundMovements, ExerciseId = ExId_CleanAndPress, Order = 5, Sets = 3, Reps = "6", RestTimeSeconds = 120 },

                // ===== Isolation Work =====
                new WorkoutExercise { WorkoutId = WkId_IsolationWork, ExerciseId = ExId_BicepCurl, Order = 1, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_IsolationWork, ExerciseId = ExId_TricepExtension, Order = 2, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_IsolationWork, ExerciseId = ExId_LateralRaise, Order = 3, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_IsolationWork, ExerciseId = ExId_LegCurl, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_IsolationWork, ExerciseId = ExId_CalfRaise, Order = 5, Sets = 4, Reps = "20", RestTimeSeconds = 20 },

                // ===== Cardio Core Combo =====
                new WorkoutExercise { WorkoutId = WkId_CardioCore, ExerciseId = ExId_HighKnees, Order = 1, Sets = 4, Reps = "45 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_CardioCore, ExerciseId = ExId_Plank, Order = 2, Sets = 3, Reps = "45 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_CardioCore, ExerciseId = ExId_Burpee, Order = 3, Sets = 3, Reps = "12", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_CardioCore, ExerciseId = ExId_MountainClimber, Order = 4, Sets = 3, Reps = "20", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_CardioCore, ExerciseId = ExId_BicycleCrunches, Order = 5, Sets = 3, Reps = "20", RestTimeSeconds = 20 },

                // ===== Strength Endurance =====
                new WorkoutExercise { WorkoutId = WkId_StrengthEndurance, ExerciseId = ExId_GobletSquat, Order = 1, Sets = 4, Reps = "20", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_StrengthEndurance, ExerciseId = ExId_Pushup, Order = 2, Sets = 4, Reps = "20", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_StrengthEndurance, ExerciseId = ExId_DBRow, Order = 3, Sets = 4, Reps = "15 per arm", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_StrengthEndurance, ExerciseId = ExId_KettlebellSwing, Order = 4, Sets = 3, Reps = "25", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_StrengthEndurance, ExerciseId = ExId_Plank, Order = 5, Sets = 3, Reps = "60 seconds", RestTimeSeconds = 30 },

                // ===== Plyometric Power =====
                new WorkoutExercise { WorkoutId = WkId_PlyometricPower, ExerciseId = ExId_BoxJump, Order = 1, Sets = 5, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_PlyometricPower, ExerciseId = ExId_JumpSquat, Order = 2, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_PlyometricPower, ExerciseId = ExId_JumpLunge, Order = 3, Sets = 4, Reps = "8 per leg", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_PlyometricPower, ExerciseId = ExId_Burpee, Order = 4, Sets = 3, Reps = "15", RestTimeSeconds = 45 },
                new WorkoutExercise { WorkoutId = WkId_PlyometricPower, ExerciseId = ExId_BearCrawl, Order = 5, Sets = 3, Reps = "30 seconds", RestTimeSeconds = 45 },

                // ===== Circuit Training =====
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_Squat, Order = 1, Sets = 3, Reps = "15", RestTimeSeconds = 20, Instructions = "Perform circuit style with minimal rest." },
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_Pushup, Order = 2, Sets = 3, Reps = "15", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_Lunge, Order = 3, Sets = 3, Reps = "10 per leg", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_DBRow, Order = 4, Sets = 3, Reps = "12 per arm", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_Burpee, Order = 5, Sets = 3, Reps = "12", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_CircuitTraining, ExerciseId = ExId_Plank, Order = 6, Sets = 3, Reps = "45 seconds", RestTimeSeconds = 60, Instructions = "Rest 60s after completing full circuit." },

                // ===== Advanced Athlete Program =====
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_CleanAndPress, Order = 1, Sets = 5, Reps = "5", RestTimeSeconds = 120 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_Deadlift, Order = 2, Sets = 5, Reps = "5", RestTimeSeconds = 150 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_BoxJump, Order = 3, Sets = 4, Reps = "8", RestTimeSeconds = 90 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_PullUp, Order = 4, Sets = 4, Reps = "10", RestTimeSeconds = 75 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_Thruster, Order = 5, Sets = 4, Reps = "12", RestTimeSeconds = 60 },
                new WorkoutExercise { WorkoutId = WkId_AdvancedAthlete, ExerciseId = ExId_SprintInterval, Order = 6, Sets = 6, Reps = "30 seconds", RestTimeSeconds = 90 },

                // ===== Weight Loss Special =====
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_Burpee, Order = 1, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_JumpSquat, Order = 2, Sets = 4, Reps = "15", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_MountainClimber, Order = 3, Sets = 4, Reps = "25", RestTimeSeconds = 20 },
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_KettlebellSwing, Order = 4, Sets = 4, Reps = "20", RestTimeSeconds = 30 },
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_HighKnees, Order = 5, Sets = 4, Reps = "45 seconds", RestTimeSeconds = 15 },
                new WorkoutExercise { WorkoutId = WkId_WeightLossSpecial, ExerciseId = ExId_RopeJump, Order = 6, Sets = 4, Reps = "60 seconds", RestTimeSeconds = 30 }
            };
    }
}













/*Valid characters for a GUID
 * 
 * 
 * 0 1 2 3 4 5 6 7 8 9
a b c d e f   (or A B C D E F)
 

❌ Invalid characters

Anything outside hex:

g h i j k l ...
 
 * */