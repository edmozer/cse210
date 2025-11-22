using System;
using System.Collections.Generic;
using YouTubeVideos;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Video 1
            Video v1 = new Video("How to Bake Bread", "Chef Ana", 420);
            v1.AddComment(new Comment("Lucas", "Great tutorial!"));
            v1.AddComment(new Comment("Maria", "I love baking bread."));
            v1.AddComment(new Comment("John", "Can you make a sourdough version?"));
            videos.Add(v1);

            // Video 2
            Video v2 = new Video("Top 10 Soccer Goals", "SportZone", 600);
            v2.AddComment(new Comment("Carlos", "Amazing goals!"));
            v2.AddComment(new Comment("Ana", "Number 3 was the best."));
            v2.AddComment(new Comment("Pedro", "I remember watching these live."));
            videos.Add(v2);

            // Video 3
            Video v3 = new Video("Learn C# in 30 Minutes", "CodeAcademy", 1800);
            v3.AddComment(new Comment("Julia", "Very helpful, thanks!"));
            v3.AddComment(new Comment("Sam", "Can you do a Java version?"));
            v3.AddComment(new Comment("Ravi", "Clear explanations."));
            videos.Add(v3);

            // Video 4
            Video v4 = new Video("Travel Vlog: Japan", "Wanderlust", 900);
            v4.AddComment(new Comment("Mika", "Beautiful places!"));
            v4.AddComment(new Comment("Sophie", "I want to visit Japan now."));
            v4.AddComment(new Comment("Tom", "Great video editing."));
            videos.Add(v4);

            // Display all videos and comments
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.GetTitle()}");
                Console.WriteLine($"Author: {video.GetAuthor()}");
                Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine();
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
                }
                Console.WriteLine();
            }
        }
    }
}
