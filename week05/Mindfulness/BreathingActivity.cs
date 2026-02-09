/*
BreathingActivity

BreathingActivity()
Run(): void
*/

using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.\n Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartMessage();
        int halfDuration = _duration / 2;

        Console.WriteLine("Breathe in...");
        ShowCountdown(halfDuration);

        Console.WriteLine("Now breathe out...");
        ShowCountdown(halfDuration);

        DisplayEndMessage();
    }
}