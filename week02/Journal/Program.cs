using System;


// Journal Program
// This program helps users keep a journal by providing daily prompts,
// saving entries, and allowing them to review past entries.

// Exceeding Requirements I achieved:
// 1. I added more 2 prompts than the expected ones
// 2. I added a confirmation before quitting to prevent accidental data loss
// 3. I added error handling for file operations
// 4. I added empty journal handling to show a helpful message when no entries exist
 

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool quit = false;
        
        while (!quit)
        {
            // Display the menu
            DisplayMenu();
            
            // Get user choice
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            
            switch (choice)
            {
                case "1":
                    // Write a new entry
                    journal.AddEntry();
                    break;
                
                case "2":
                    // Display the journal
                    journal.DisplayAll();
                    break;
                
                case "3":
                    // Load the journal from a file
                    journal.LoadFromFile();
                    break;
                
                case "4":
                    // Save the journal to a file
                    journal.SaveToFile();
                    break;
                
                case "5":
                    // Use the Journal's Quit method
                    quit = journal.Quit();
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        }
    }
    
    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Journal Menu:");
        Console.WriteLine();
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load journal from file");
        Console.WriteLine("4. Save journal to file");
        Console.WriteLine("5. Quit");
    }
}