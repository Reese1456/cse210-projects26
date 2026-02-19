using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Running(new DateTime(2022, 11, 5), 45, 4.5),
            new Cycling(new DateTime(2022, 11, 7), 60, 15.0),
            new Cycling(new DateTime(2022, 11, 9), 40, 12.5),
            new Swimming(new DateTime(2022, 11, 10), 30, 20),
            new Swimming(new DateTime(2022, 11, 12), 45, 30),
        };

        Console.WriteLine("=== Exercise Activity Summary ===\n");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}