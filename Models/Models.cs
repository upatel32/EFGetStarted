using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.Models
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Set> Set { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=workingOut.db");
    }

    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public List<Set> Sets { get; set; }
    }

    public class Set
    {
        public int SetId { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}