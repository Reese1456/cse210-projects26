using System;
using System.Collections.Generic;

/*
PromptGenerator

_prompts : List<string>

GetRandomPrompt() : string
*/
public class PromptGenerator
{
    private List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.AddRange(new List<string> {
            "What were you grateful for today? ",
            "What challenges were you able to overcome today? ",
            "What would you have done differently today? ",
            "How did you feel at the start of the day and at the end of the day? ",
            "Were there any challenges you couldnt over come today? ",
            "Do you have any plans for tomorrow? ",
            "What made you smile today? "
        });
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

}