using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielLewis.WordProcessing.Core
{
    public class WordSplitter
    {
        private static readonly string[] _punctuationChars = new string[] { ",", ".", "(", ")", ":", ";", "'", "!", "`" };
        private static readonly string[] _wordBreakers = new string[] { " ", "\n", "\r\n" };

        /// <summary>
        /// Splits the text into a string array of words using spaces and new-line characters. Ignores punctuation characters and returns
        /// words in ascending order.
        /// </summary>
        /// <param name="text">The text to split</param>
        /// <returns>A string array of sorted words in the text, minus puncuation</returns>
        public string[] SplitWordsAndSort(string text)
        {
            try
            {
                // flatten the text so that words will match regardless of casing..
                text = text.ToLower();

                // clear out punctuation as this should not be included in the words;
                text = RemovePunctuationCharacters(text);

                string[] allWords = text
                    .Split(_wordBreakers, StringSplitOptions.RemoveEmptyEntries) // split the words-up using the word breakers specified.
                    .OrderBy(w => w) // this will use linq to order the words
                    .ToArray(); // explicitly load into an array so linq does not try to lazily evaluate all the time

                return allWords;
            }
            catch(Exception ex)
            {
                // log etc
                throw;
            }
        }

        private string RemovePunctuationCharacters(string fileText)
        {
            foreach (var punctuationChar in _punctuationChars)
            {
                fileText = fileText.Replace(punctuationChar, "");
            }

            return fileText;
        }
    }
}
