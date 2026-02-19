using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace LetterboxdWatchlistRandomMovieSelector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MovieSelector movieSelector = new MovieSelector();
            bool exit = false;

            movieSelector.createAsciiHeading();
            movieSelector.generateRandomMovie();

            while (!exit)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[DarkOrange]What would you like to do?[/]")
                    .AddChoices("New Movie?", "Exit"));

                if (choice == "New Movie?")
                {
                    movieSelector.generateRandomMovie();
                }
                else if (choice == "Exit")
                {
                    exit = true;
                }
            }
        }
    }
}
