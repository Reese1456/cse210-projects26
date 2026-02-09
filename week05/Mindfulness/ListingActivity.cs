/*
ListingActivity

_count: int
_prompts: List<string>

ListingActivity()
Run(): void
GetRandomPrompt(): void
GetListFromUser(): List<string>
*/

using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having\n you list as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        GetRandomPrompt();
        Console.WriteLine();

        List<string> responses = GetListFromUser();

        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndMessage();
    }

    private void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                responses.Add(response);
            }
        }

        return responses;
    }
}