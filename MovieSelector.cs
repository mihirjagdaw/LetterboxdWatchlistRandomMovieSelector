using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterboxdWatchlistRandomMovieSelector
{
    internal class MovieSelector
    {
        // Dictionary to store movie names and years
        private Dictionary<string, string> movies = new Dictionary<string, string>();

        // Constructor to read the CSV file and populate the movies dictionary
        public MovieSelector()
        {
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

        // Method to generate a random movie and print its torrent link
        public void generateRandomMovie()
        {
            var random = new Random();
            int randomIndex = random.Next(0, movies.Count);
            var randomMovie = movies.ElementAt(randomIndex).Key;
            var movieYear = movies.ElementAt(randomIndex).Value;

            string movieName = randomMovie.Replace(" ", "-").ToLower();

            // Print the randomly selected movie and its torrent link
            Console.WriteLine($"Randomly selected movie: {randomMovie}");

            Console.WriteLine($"Torrent Link: https://yts.bz/movies/{movieName}-{movieYear}");
        }
    }
}
