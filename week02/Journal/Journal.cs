using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Member variables
    public List<Entry> _entries = new List<Entry>();
    
    // Create an instance of the PromptGenerator
    private PromptGenerator _promptGenerator = new PromptGenerator();
    
    private bool _hasUnsavedChanges = false;

    // Method to add a new entry
    public void AddEntry()
    {
        // Get the current date
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        
        // Get a random prompt from the prompt generator
        string prompt = _promptGenerator.GetRandomPrompt();
        
        // Display the prompt and get user input
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        
        // Create a new entry and add it to the list
        Entry newEntry = Entry.CreateEntry(date, prompt, response);
        _entries.Add(newEntry);
        
        // Mark that we have unsaved changes
        _hasUnsavedChanges = true;
        
        Console.WriteLine("Entry added successfully!");
    }

    // Method to display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine("===============");
        
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save the journal to a file
    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.FormatForSaving());
                }
            }
            
            Console.WriteLine("Journal saved successfully!");
            _hasUnsavedChanges = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Method to load the journal from a file
    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }
        
        try
        {
            // Clear existing entries
            _entries.Clear();
            
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                // Split the line into its components
                string[] parts = line.Split("|");
                
                if (parts.Length >= 3)
                {
                    // Create a new entry with the data from the file
                    string date = parts[0];
                    string prompt = parts[1];
                    string text = parts[2];
                    
                    Entry entry = Entry.CreateEntry(date, prompt, text);
                    _entries.Add(entry);
                }
            }
            
            Console.WriteLine("Journal loaded successfully!");
            _hasUnsavedChanges = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
    
    // Method to handle quitting the program
    public bool Quit()
    {
        // Check if there are unsaved changes
        if (_hasUnsavedChanges)
        {
            Console.WriteLine("You have unsaved journal entries.");
            Console.Write("Would you like to save before quitting? (y/n): ");
            string saveChoice = Console.ReadLine().ToLower();
            
            if (saveChoice == "y" || saveChoice == "yes")
            {
                SaveToFile();
            }
        }
        
        Console.Write("Are you sure you want to quit? (y/n): ");
        string confirmation = Console.ReadLine().ToLower();
        
        if (confirmation == "y" || confirmation == "yes")
        {
            Console.WriteLine("Thank you for using the Journal Program!");
            return true;
        }
        
        return false;
    }
}