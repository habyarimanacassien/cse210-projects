public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<int> _usedPromptIndices;

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        _usedPromptIndices = new List<int>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        // Display a random prompt
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        // Count items listed
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(item))
            {
                count++;
            }
            
            // Check if time's up after each entry
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");
        
        DisplayEndingMessage();
    }
    
    // Get a random prompt that hasn't been used yet
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index;
        
        // If all prompts have been used, reset the list
        if (_usedPromptIndices.Count >= _prompts.Count)
        {
            _usedPromptIndices.Clear();
        }
        
        // Find an unused prompt
        do
        {
            index = random.Next(_prompts.Count);
        } while (_usedPromptIndices.Contains(index));
        
        // Mark this prompt as used
        _usedPromptIndices.Add(index);
        
        return _prompts[index];
    }
}