/*
_prompts: List<string>
_questions: List<string>

ReflectingActivity()
Run(): void
GetRandomPrompt(): string
GetRandomQuestion(): string
DisplayPrompt(): void
DisplayQuestion(): void
*/

using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.\n This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?"
        };
    }

    public void Run()
    {
        DisplayStartMessage();
        DisplayPrompt();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShoweSpinner(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShoweSpinner(10);
        }

        DisplayEndMessage();
    }

    private void DisplayPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private void DisplayQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        Console.WriteLine($"> {_questions[index]}");
    }
}