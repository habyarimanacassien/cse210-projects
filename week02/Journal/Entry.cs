using System;

public class Entry
{
    // Member variables
    public string _date;
    public string _promptText;
    public string _entryText;

    // Constructor
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }

    // Method to format the entry as a string for saving to a file
    public string FormatForSaving()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}