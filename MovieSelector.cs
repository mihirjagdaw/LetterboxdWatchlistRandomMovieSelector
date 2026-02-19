using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace LetterboxdWatchlistRandomMovieSelector
{
    internal class MovieSelector
    {
        // Dictionary to store movie names and years
        private Dictionary<string, string> movies = new Dictionary<string, string>();

        // Constructor to read the CSV file and populate the movies dictionary
        public MovieSelector()
        {
            // users currrently have to copy the path of the csv file from their downloads folder and paste it here
            using (var reader = new StreamReader(@"C:\\Users\\mihir\\Downloads\\watchlist-fortnutmastr006-2026-02-15-16-24-utc.csv"))
            {
                var values = new string[4];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    values = line.Split(',');
                    movies.Add(values[1], values[2]);

                }
            }
        }


        // Method to create cool ascii heading
        public void createAsciiHeading()
        {
            // Clear console for fresh display
            AnsiConsole.Clear();

            // Big fancy title
            AnsiConsole.Write(new FigletText("MOVIE RANDOMIZER")
                .Centered()
                .Color(Color.White));

            AnsiConsole.WriteLine();
        }

        // Method to draw a line with letterboxd logo emojis
        public void drawLine()
        {
            AnsiConsole.Write(new Rule
            {
                Border = BoxBorder.Rounded, 
                Justification = Justify.Left, 
                Style = Style.Parse("SteelBlue"),
                Title = "\ud83d\udfe0\ud83d\udfe2\ud83d\udd35"
            });

            Console.WriteLine();
        }

        // Method to generate a random movie and print its torrent link
        public void generateRandomMovie()
        {
            var random = new Random();
            int randomIndex = random.Next(0, movies.Count);
            var randomMovie = movies.ElementAt(randomIndex).Key;
            var movieYear = movies.ElementAt(randomIndex).Value;

            string movieName = randomMovie.Replace(" ", "-").ToLower();

            // Print the randomly selected movie and its torrent link
            drawLine();
            AnsiConsole.MarkupLine($"Randomly selected movie: [Green]{randomMovie}[/]");

            AnsiConsole.MarkupLine($"Torrent Link: [Blue]https://yts.bz/movies/{movieName}-{movieYear}[/]");
        }
    }
}
