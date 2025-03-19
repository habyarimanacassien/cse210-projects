using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Member variable to store prompts
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I grateful for today?",
        "What did I learn today?"
    };

    // Method to get a random prompt from the list
    public string GetRandomPrompt()
    {
        // Create a random number generator
        Random random = new Random();
        
        // Generate a random index based on the number of prompts
        int promptIndex = random.Next(_prompts.Count);
        
        // Return the prompt at the randomly selected index
        return _prompts[promptIndex];
    }
}