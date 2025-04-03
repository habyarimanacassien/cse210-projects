using System;
using System.Collections.Generic;

// Main program class
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Video Program\n");

        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Video 1 with comments
        Video video1 = new Video("Learning C# abstraction fundamentals", "Cassien H", 720);
        video1.AddComment(new Comment("Habyarimana", "This really helped me understand classes!"));
        video1.AddComment(new Comment("Beatrice M", "Great explanation of abstraction."));
        video1.AddComment(new Comment("Student", "Could you make a video about Encapsulation next?"));
        video1.AddComment(new Comment("John", "I watched this three times and finally get it!"));
        videos.Add(video1);

        // Video 2 with comments
        Video video2 = new Video("10 Advanced Calculus", "Maths expert", 540);
        video2.AddComment(new Comment("Person X", "The derivative comprehension tips were super helpful!"));
        video2.AddComment(new Comment("Milla N", "I've been learning calculus for years but yours is interesting."));
        video2.AddComment(new Comment("Maths lover", "Great video, but you missed some important theorems."));
        videos.Add(video2);

        // Video 3 with comments
        Video video3 = new Video("English speaking", "LearnEng", 1200);
        video3.AddComment(new Comment("Kider", "Do you think these frameworks are helping no English speakers?"));
        video3.AddComment(new Comment("Maniu", "Very interesting!"));
        video3.AddComment(new Comment("Baby", "I appreciate the focus on Passive voice."));
        video3.AddComment(new Comment("Emma K", "Some of your speaking are faster."));
        videos.Add(video3);

        // Display information for all videos
        foreach (Video video in videos)
        {
            Console.WriteLine("videoTitle: " + video.GetVideoTitle());
            Console.WriteLine("videoAuthor: " + video.GetVideoAuthor());
            Console.WriteLine("Length (in seconds): " + video.GetVideoLength());
            Console.WriteLine("Number of comments: " + video.GetNumberOfCommentsList());
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetCommentsList())
            {
                Console.WriteLine("  - " + comment.GetnameCommentor() + ": " + comment.GetcommentText());
            }
            
            Console.WriteLine(); // Empty line between videos
        }
    }
}
