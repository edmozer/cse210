using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Create one activity of each type
        Running running = new Running("03 Nov 2022", 30, 4.8);
        Cycling cycling = new Cycling("03 Nov 2022", 30, 20.0);
        Swimming swimming = new Swimming("03 Nov 2022", 30, 20);

        // Add activities to the list
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Iterate through the list and display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
