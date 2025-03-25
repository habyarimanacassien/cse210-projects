using System;

/*
* Scripture Memorizer Program
* 
* This program has the following features that exceed the core requirements:
* 
* 1. Selects random words that are not already hidden (rather than potentially selecting
*    already hidden words), making the memorization process more efficient.
* 
* 2. Works with a library of scriptures instead of a single one, randomly selecting 
*    a scripture to present to the user each time they run the program, providing variety 
*    and helping users memorize multiple scriptures.
* 
* 3. Allows users to adjust difficulty by changing the number of words hidden in each step
*    through a menu at the beginning.
* 
* 4. Provides progress updates to the user, showing what percentage of the scripture
*    has been hidden so far.
*/

class Program
{
    static void Main(string[] args)
    {
        // Create scripture library
        ScriptureLibrary library = new ScriptureLibrary();
        
        // Get a random scripture
        Scripture scripture = library.GetRandomScripture();
        
        // Welcome message
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine("This program will help you memorize scriptures by gradually hiding words.");
        Console.WriteLine();
        
        // Ask user for difficulty level (number of words to hide each time)
        Console.WriteLine("Choose difficulty level:");
        Console.WriteLine("1. Easy (1 word hidden each time)");
        Console.WriteLine("2. Medium (3 words hidden each time)");
        Console.WriteLine("3. Hard (5 words hidden each time)");
        Console.Write("Enter your choice (1-3): ");
        
        int wordsToHideEachTime = 3; // Default is medium
        string difficultyChoice = Console.ReadLine();
        if (difficultyChoice == "1")
        {
            wordsToHideEachTime = 1;
        }
        else if (difficultyChoice == "3")
        {
            wordsToHideEachTime = 5;
        }
        
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.\n");
        
        // Main program loop
        while (true)
        {
            // Clear the console
            Console.Clear();
            
            // Display the scripture
            Console.WriteLine(scripture.GetDisplayText());
            
            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCongratulations! You have memorized the scripture!");
                break;
            }
            
            // Prompt user
            Console.Write("\nPress Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();
            
            // Check if user wants to quit
            if (input.ToLower() == "quit")
            {
                break;
            }
            
            // Hide random words
            scripture.HideRandomWords(wordsToHideEachTime);
        }
    }
}