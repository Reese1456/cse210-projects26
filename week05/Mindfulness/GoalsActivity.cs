/*
Goals

BreathingActivity()
Run(): void


*/

using System;

public class GoalsActivity : Activity
{
    public GoalsActivity()
    {
        _name = "Goals";
        _description = "This activity will help you set and achieve your goals by guiding you through a process of reflection and planning.";
    }

    public void Run()
    {
        DisplayStartMessage();
        Console.WriteLine("Take a moment to think about a goal you want to achieve.");
        ShowSpinner(5);
        Console.WriteLine("Now, let's break that goal down into smaller, actionable steps.");
        ShowSpinner(3);
        Console.WriteLine("Write down the first step you can take towards achieving your goal:");
        string firstStep = Console.ReadLine();
        ShowSpinner(3);
        Console.WriteLine($"Great! Your first step is: {firstStep}");
        Console.WriteLine("Now, think about the next steps you need to take to achieve your goal.");
        ShowSpinner(5);
        Console.WriteLine("Write down the next step:");
        string nextStep = Console.ReadLine();
        ShowSpinner(3);
        Console.WriteLine($"Awesome! Your next step is: {nextStep}");
        Console.WriteLine("Keep breaking down your goal into smaller steps until you have a clear plan of action.");
        DisplayEndMessage();
    }
}