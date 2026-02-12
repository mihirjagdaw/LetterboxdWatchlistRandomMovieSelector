using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterboxdWatchlistRandomMovieSelector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\\Users\\mihir\\Downloads\\watchlist-fortnutmastr006-2026-02-12-07-49-utc.csv"))
            {
                Dictionary <string, string> movies = new Dictionary<string, string>();
                var values = new string[4];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    values = line.Split(',');
                    movies.Add(values[1], values[2]);

                }
                var random = new Random();
                int randomIndex = random.Next(0, movies.Count);
                var randomMovie = movies.ElementAt(randomIndex).Key;
                var movieYear = movies.ElementAt(randomIndex).Value;
                Console.WriteLine($"Randomly selected movie: {randomMovie}");

                string movieName = randomMovie.Replace(" ", "-").ToLower();
                
                Console.WriteLine($"Torrent Link: https://yts.bz/movies/{movieName}-{movieYear}");
            }

        }
    }
}
