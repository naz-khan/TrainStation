using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrainStation
{
    public class StationFinder : IStationFinder
    {
        List<string> Stations { get; set; }

        public Suggestions GetSuggestions(string userInput)
        {
            Suggestions suggestions = new Suggestions();
            Stations = File.ReadLines("../../Stations.txt").ToList();
            suggestions.Stations = Stations.Where(item => item.StartsWith(userInput, StringComparison.CurrentCulture)).ToList();

            List<char> remainingLetters = new List<char>();
            foreach (string item in suggestions.Stations)
            {
                var remainingChars = item.Replace(userInput, "");
                remainingChars = remainingChars.Replace(" ","");

                if (!string.IsNullOrEmpty(remainingChars))
                {
                    remainingChars = Regex.Replace(remainingChars, @"[^0-9a-zA-Z\._]", string.Empty);
                    var currentChar = char.Parse(remainingChars.Substring(0, 1));
                    if (char.IsLetterOrDigit(currentChar))
                    {
                        remainingLetters.Add(currentChar);
                    }
                }      
            }
            suggestions.NextLetters = remainingLetters;
            return suggestions;
        }
    }

    public class Suggestions
    {
        public List<char> NextLetters { get; set; }
        public IEnumerable<string> Stations { get; set; }
    }
}
