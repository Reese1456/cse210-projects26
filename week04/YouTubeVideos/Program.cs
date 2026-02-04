using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics Tutorial", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Helped me a lot."));
        video1.AddComment(new Comment("Charlie", "Can you make an advanced version?"));
        video1.AddComment(new Comment("Bryce", "Thanks for sharing!"));

        // Video 2
        Video video2 = new Video("Understanding OOP", "DevSimplified", 720);
        video2.AddComment(new Comment("Dave", "OOP finally makes sense."));
        video2.AddComment(new Comment("Emma", "Awesome examples."));
        video2.AddComment(new Comment("Frank", "Best tutorial so far."));

        // Video 3
        Video video3 = new Video("LINQ in C#", "TechGuru", 540);
        video3.AddComment(new Comment("Grace", "LINQ is powerful!"));
        video3.AddComment(new Comment("Henry", "Very clear tutorial."));
        video3.AddComment(new Comment("Ivy", "Thanks for this."));
        video3.AddComment(new Comment("Greg", "That was great!"));
        video3.AddComment(new Comment("Brian", "Thumbs up!"));

        // Add videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.LengthSeconds);
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine("----------------------------------");
        }
    }
}