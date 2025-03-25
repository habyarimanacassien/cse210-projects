using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the displayed text (original text or underscores if hidden)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace each letter with an underscore
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    // Get original text
    public string GetText()
    {
        return _text;
    }
}
