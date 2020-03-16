using System;
using System.IO;
using EFGetStarted.Models;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = args[0];
            Console.WriteLine(year);
            StreamReader sr = new StreamReader($"/Users/vimana/Desktop/Projects/EFGetStarted/{year}.txt");
            string[] read;
            string line;
            string currentDay;
            DateTimeOffset currentDate;
            string currentExercise;

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                line = line.ToLower();
                if (line.Contains("day"))
                {
                    currentDay = line;
                    Console.WriteLine(currentDay);
                }
                else if (line.Contains("/"))
                {
                    line = line.Insert(line.Length, $"/{year}");
                    currentDate = DateTimeOffset.Parse(line);
                    Console.WriteLine(currentDate);
                }
                else if (!line.Contains("x"))
                {
                    currentExercise = line;
                    Console.WriteLine(currentExercise);
                }
                else
                {
                    var set = line.Split('x');
                    Console.WriteLine("weight " + set[0] + "lbs for " + set[1] + " reps");
                }
            }
            using (var db = new WorkoutContext())
            {
                Console.WriteLine();
            }
        }
    }
}