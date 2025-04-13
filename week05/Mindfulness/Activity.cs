public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();
    private const string _logFile = "activity_log.txt";

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        LoadActivityLog();
    }

    // Display starting message and get duration from user
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
    }

    // Display ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        
        // Log this activity completion
        LogActivityCompletion();
        
        ShowSpinner(4);
    }

    // Show spinner animation
    protected void ShowSpinner(int seconds)
    {
        List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\" };
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        int i = 0;
        
        while (DateTime.Now < endTime)
        {
            string frame = spinnerFrames[i];
            Console.Write(frame);
            Thread.Sleep(240);
            Console.Write("\b \b");
            
            i++;
            if (i >= spinnerFrames.Count)
            {
                i = 0;
            }
        }
    }

    // Show countdown animation
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Log activity completion
    private void LogActivityCompletion()
    {
        if (_activityLog.ContainsKey(_name))
        {
            _activityLog[_name]++;
        }
        else
        {
            _activityLog[_name] = 1;
        }
        
        SaveActivityLog();
    }
    
    // Load activity log from file
    private void LoadActivityLog()
    {
        if (File.Exists(_logFile))
        {
            string[] lines = File.ReadAllLines(_logFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string activityName = parts[0];
                    int count = int.Parse(parts[1]);
                    _activityLog[activityName] = count;
                }
            }
        }
    }
    
    // Save activity log to file
    private void SaveActivityLog()
    {
        List<string> lines = new List<string>();
        foreach (var entry in _activityLog)
        {
            lines.Add($"{entry.Key},{entry.Value}");
        }
        
        File.WriteAllLines(_logFile, lines);
    }
    
    // Display activity log
    public static void DisplayActivityLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("===========");
        
        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            Console.WriteLine("Activity Completion Count:");
            foreach (var entry in _activityLog)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} times");
            }
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}