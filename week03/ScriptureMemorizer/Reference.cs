using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse reference
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse; // Same as start verse for a single verse
    }

    // Constructor for a verse range reference
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Get the formatted reference string
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            // Single verse format
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            // Verse range format
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
