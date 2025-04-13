public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowBreathCountdown(4);
            
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowBreathCountdown(3);
            
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }
      
    // Show breathing countdown animation with seconds display
    private void ShowBreathCountdown(int seconds)
    {
        // Display countdown numbers
        for (int i = seconds; i >= 1; i--)
        {
            // Display the current number
            Console.Write($" {i}");
            
            // Wait for 1 second
            Thread.Sleep(1000);
            
            // Erase the number
            Console.Write("\b\b  \b\b");
        }
    }
}