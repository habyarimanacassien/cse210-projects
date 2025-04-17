using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create one instance of each activity type
        Running running = new Running(
            DateTime.Parse("2022-11-03"), 
            30, 
            3.0); // 3.0 miles

        Cycling cycling = new Cycling(
            DateTime.Parse("2022-11-04"), 
            45, 
            15.0); // 15.0 mph

        Swimming swimming = new Swimming(
            DateTime.Parse("2022-11-05"), 
            60, 
            40); // 40 laps

        // Add all activities to a list of the base type
        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Program\n");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
