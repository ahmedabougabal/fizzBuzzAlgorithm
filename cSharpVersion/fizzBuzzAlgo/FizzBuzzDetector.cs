using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace fizzBuzzAlgo
{
    /// <summary>
    /// Class that detects and replaces words in a string according to FizzBuzz rules.
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// Processes the input string and replaces every third word with "Fizz" and every fifth word with "Buzz".
        /// If a word is both the third and fifth word, it is replaced with "FizzBuzz".
        /// </summary>
        /// <param name="input">The input string to process.</param>
        /// <returns>A result object containing the processed string and the count of replacements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        /// <exception cref="ArgumentException">Thrown when input string length is less than 7 or greater than 100.</exception>
        public FizzBuzzResult GetOverlappings(string input)
        {
            // Validate input
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null");
        
            if (input.Length < 7 || input.Length > 100)
                throw new ArgumentException($"Input string length must be between 7 and 100, but was {input.Length}");

            // First, extract all words to count them properly
            string pattern = @"[a-zA-Z0-9]+";
            var allMatches = Regex.Matches(input, pattern);
            var words = new List<(string word, int startIndex, int endIndex)>();
            
            foreach (Match match in allMatches)
            {
                words.Add((match.Value, match.Index, match.Index + match.Length));
            }

            // Now process the input line by line
            string[] lines = input.Split('\n');
            StringBuilder outputBuilder = new StringBuilder();
            int replacementCount = 0;
            int currentWordIndex = 0;
            int currentPos = 0;

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                if (lineIndex > 0)
                {
                    outputBuilder.Append('\n');
                    currentPos++; // Account for the newline character
                }

                string line = lines[lineIndex];
                int lineStart = currentPos;
                int lineEnd = lineStart + line.Length;

                // Find words that belong to this line
                while (currentWordIndex < words.Count && words[currentWordIndex].startIndex < lineEnd)
                {
                    var (word, startIndex, endIndex) = words[currentWordIndex];
                    
                    // Add any text before this word
                    if (startIndex > currentPos)
                    {
                        outputBuilder.Append(input.Substring(currentPos, startIndex - currentPos));
                    }

                    // Apply FizzBuzz rules
                    bool isFizz = (currentWordIndex + 1) % 3 == 0;
                    bool isBuzz = (currentWordIndex + 1) % 5 == 0;

                    if (isFizz && isBuzz)
                    {
                        outputBuilder.Append("FizzBuzz");
                        replacementCount++;
                    }
                    else if (isFizz)
                    {
                        outputBuilder.Append("Fizz");
                        replacementCount++;
                    }
                    else if (isBuzz)
                    {
                        outputBuilder.Append("Buzz");
                        replacementCount++;
                    }
                    else
                    {
                        outputBuilder.Append(word);
                    }

                    currentPos = endIndex;
                    currentWordIndex++;
                }

                // Add any remaining text in this line
                if (lineEnd > currentPos)
                {
                    outputBuilder.Append(input.Substring(currentPos, lineEnd - currentPos));
                    currentPos = lineEnd;
                }
            }

            return new FizzBuzzResult
            {
                OutputString = outputBuilder.ToString(),
                Count = replacementCount
            };
        }
    }
}