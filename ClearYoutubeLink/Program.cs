using System;
using System.Text.RegularExpressions;

public class Program
{
    public static string CleanYoutubeUrl(string url)
    {
        Match videoIdMatch = Regex.Match(url, @"(?:v=|/)([0-9A-Za-z_-]{11})");
        if (videoIdMatch.Success)
        {
            return $"https://www.youtube.com/watch?v={videoIdMatch.Groups[1].Value}";
        }
        return null;
    }

    public static string CleanPlaylistUrl(string url)
    {
        Match playlistIdMatch = Regex.Match(url, @"list=([0-9A-Za-z_-]+)");
        if (playlistIdMatch.Success)
        {
            return $"https://www.youtube.com/playlist?list={playlistIdMatch.Groups[1].Value}";
        }
        return null;
    }

    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("paste here youtube link: ");
            string youtubeLink = Console.ReadLine().Trim();

            string[] links = Regex.Split(youtubeLink, @",\s*|\s+");

            foreach (string link in links)
            {
                string cleanLink = CleanYoutubeUrl(link);
                string cleanPlaylistLink = CleanPlaylistUrl(link);
                if (cleanLink != null)
                {
                    Console.WriteLine($"url on video: {cleanLink}");
                    Console.WriteLine($"url on playlist: {cleanPlaylistLink}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
    }
}

