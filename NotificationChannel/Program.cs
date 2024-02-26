using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] notificationTitles = {
            "[BE][Urgent] Backend server down",
            "[QA][FE] UI bug detected",
            "[Urgent][BE] Database connection issue",
            "[QA] Manual testing required"
        };

        foreach (string title in notificationTitles)
        {
            List<string> channels = ParseNotificationChannels(title);
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Channels: {string.Join(", ", channels)}");
            Console.WriteLine();
        }
    }

    static List<string> ParseNotificationChannels(string title)
    {
        List<string> channels = new List<string>();
        string pattern = @"\[(.*?)\]";
        MatchCollection matches = Regex.Matches(title, pattern);

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            switch (tag.ToLower())
            {
                case "be":
                    channels.Add("Backend");
                    break;
                case "fe":
                    channels.Add("Frontend");
                    break;
                case "qa":
                    channels.Add("Quality Assurance");
                    break;
                case "urgent":
                    channels.Add("Urgent");
                    break;
                default:
                    // Ignore irrelevant tags
                    break;
            }
        }

        return channels.Distinct().ToList(); // Remove duplicates
    }
}
