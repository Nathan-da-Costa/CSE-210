using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Tutorial for Beginners", "Code Academy", 600);
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Alice", "Very clear explanation, thanks!"));
        video1.AddComment(new Comment("Bob", "Helped me a lot with my assignment."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Abstraction in OOP Explained", "Tech With Tim", 450);
        video2.AddComment(new Comment("Charlie", "Best OOP video so far."));
        video2.AddComment(new Comment("Diana", "Could you make a video on Encapsulation next?"));
        video2.AddComment(new Comment("Ethan", "Super easy to understand."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Setup VS Code for C#", "DevTips", 300);
        video3.AddComment(new Comment("Fiona", "Saved me hours of setup!"));
        video3.AddComment(new Comment("George", "Works perfectly on Mac as well."));
        video3.AddComment(new Comment("Hannah", "Short and to the point."));
        videos.Add(video3);

        // Displaying video information
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
            Console.WriteLine();
        }
    }
}