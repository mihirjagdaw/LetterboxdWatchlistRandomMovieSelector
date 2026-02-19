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
            MovieSelector movieSelector = new MovieSelector();
            movieSelector.generateRandomMovie();
        }
    }
}
