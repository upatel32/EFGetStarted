using System.Linq.Expressions;
using System;
using EFGetStarted.Models;
using System.IO;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:/Users/upatel/Desktop/workoutparse/EFGetStarted/oldWorkoutLogs.txt");
            string[] read;
            string line;
            string currentDay;
            string currentDate;
            string currentExercise;

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.Contains("day"))
                {
                    currentDay = line;
                    Console.WriteLine(line);
                }
                else if (line.Contains("/"))
                {
                    currentDate = line;
                }
                else if (!line.Contains("x"))
                {
                    currentExercise = line;
                }
                else
                {
                    var line.Split('x');
                }
            }
            using (var db = new WorkoutContext())
            {
                Console.WriteLine();
                // db.Add(new Exercise
                // {

                // });
            }
        }
    }
}
