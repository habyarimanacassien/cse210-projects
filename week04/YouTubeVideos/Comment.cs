using System;

// Simple Comment class to track commenter names and comment text
public class Comment
{
    // Private variables (properties)
    private string _nameCommentor;
    private string _commentText;

    // Constructor - this runs when we create a new Comment
    public Comment(string nameCommentor, string commentText)
    {
        _nameCommentor = nameCommentor;
        _commentText = commentText;
    }

    // Methods to get and set the private variables
    public string GetnameCommentor()
    {
        return _nameCommentor;
    }

    public void SetnameCommentor(string nameCommentor)
    {
        _nameCommentor = nameCommentor;
    }

    public string GetcommentText()
    {
        return _commentText;
    }

    public void SetcommentText(string commentText)
    {
        _commentText = commentText;
    }
}
