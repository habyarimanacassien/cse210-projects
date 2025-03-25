using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    // Get the complete scripture text as it should be displayed
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        
        // Create a list of displayed word texts
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        
        // Join all the displayed words with spaces
        string scriptureText = string.Join(" ", displayWords);
        
        // Return the complete scripture with reference and text
        return $"{referenceText} - {scriptureText}";
    }

    // Hide random words in the scripture that are not already hidden
    public void HideRandomWords(int numberToHide)
    {
        // Get a list of words that are not hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // If there are no more visible words, return
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Ensure we don't try to hide more words than are available
        numberToHide = Math.Min(numberToHide, visibleWords.Count);
        
        // Hide the specified number of random words
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(0, visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    
    // Get the percentage of words that are hidden
    public int GetHiddenPercentage()
    {
        int hiddenCount = 0;
        
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenCount++;
            }
        }
        
        return (int)Math.Round((double)hiddenCount / _words.Count * 100);
    }
}
