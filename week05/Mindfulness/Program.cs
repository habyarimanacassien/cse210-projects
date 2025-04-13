/* 
EXCEEDING REQUIREMENTS:
I have added several enhancements to exceed the base requirements that include:

1. Activity Logging & Stats: The program keeps track of how many times each activity has been performed
   and saves this information to a file for persistence between sessions. Users can view statistics 
   about their mindfulness practice through the activity log menu option.

2. Enhanced Prompt Selection: The reflection and listing activities ensure that all prompts and
   questions are used before repeating any. This increases variety and makes each session more
   meaningful.

3. Error Handling: Added validation for user input in the menu selection.
*/

class Program
{
    static void Main(string[] args)
    {
        // Create instances of all activities
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();
        
        // Main program loop
        bool quit = false;
        while (!quit)
        {
            // Display menu
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("==================");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            // Get user choice
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    breathingActivity.Run();
                    break;
                case "2":
                    reflectionActivity.Run();
                    break;
                case "3":
                    listingActivity.Run();
                    break;
                case "4":
                    Activity.DisplayActivityLog();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        
        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}