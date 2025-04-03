using System;
using System.Collections.Generic;

// Simple Video class to track videos and their commentsList
public class Video
{
    // Private variables (properties)
    private string _videoTitle;
    private string _videoAuthor;
    private int _videoLength;
    private List<Comment> _commentsList;

    // Constructor - this runs when we create a new Video
    public Video(string videoTitle, string videoAuthor, int videoLength)
    {
        _videoTitle = videoTitle;
        _videoAuthor = videoAuthor;
        _videoLength = videoLength;
        _commentsList = new List<Comment>();
    }

    // Methods to get and set the private variables
    public string GetVideoTitle()
    {
        return _videoTitle;
    }

    public void SetVideoTitle(string videoTitle)
    {
        _videoTitle = videoTitle;
    }

    public string GetVideoAuthor()
    {
        return _videoAuthor;
    }

    public void SetVideoAuthor(string videoAuthor)
    {
        _videoAuthor = videoAuthor;
    }

    public int GetVideoLength()
    {
        return _videoLength;
    }

    public void SetLength(int videoLength)
    {
        _videoLength = videoLength;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _commentsList.Add(comment);
    }

    // Method to get all commentsList
    public List<Comment> GetCommentsList()
    {
        return _commentsList;
    }

    // Method to get the number of commentsList
    public int GetNumberOfCommentsList()
    {
        return _commentsList.Count;
    }

}
