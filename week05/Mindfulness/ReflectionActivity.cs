public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _usedPromptIndices;
    private List<int> _usedQuestionIndices;

    public ReflectionActivity() 
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
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
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
        _usedPromptIndices = new List<int>();
        _usedQuestionIndices = new List<int>();
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        // Display a random prompt
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        // Reset used questions for this session
        _usedQuestionIndices.Clear();
        
        // Loop through questions until duration is reached
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
            
            // If we've gone through all questions, reset the used questions list
            if (_usedQuestionIndices.Count >= _questions.Count)
            {
                _usedQuestionIndices.Clear();
            }
        }
        
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
    
    // Get a random question that hasn't been used yet
    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index;
        
        // If all questions have been used, reset the list
        if (_usedQuestionIndices.Count >= _questions.Count)
        {
            _usedQuestionIndices.Clear();
        }
        
        // Find an unused question
        do
        {
            index = random.Next(_questions.Count);
        } while (_usedQuestionIndices.Contains(index));
        
        // Mark this question as used
        _usedQuestionIndices.Add(index);
        
        return _questions[index];
    }
}