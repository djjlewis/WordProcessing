using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielLewis.WordProcessing.Core
{
    /// <summary>
    /// The WordCounter Class has one method, CountWords which will return a List of 
    /// WordCountResult objects detailing the word and the number of occurrences
    /// </summary>
    public class WordCounter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="words">A string array of words to count the occurrences of.</param>
        /// <returns>A List of WordCountResult objects showing each unique word, and how many times it occurred.</returns>
        public List<WordCountResult> CountWords(string[] words)
        {
            // check arguments
            if (words == null)
            {
                throw new ArgumentNullException("words");
            }

            try
            {
                // this will hold the list of word counts result objects. It will always return
                // even if empty, so no danger of null references sent to the valler
                var countedWords = new List<WordCountResult>();

                // this variable stores the last word to be processed so we don't process / sum it multiple times
                var previousWord = string.Empty;

                // loop over each word in the array
                // NOTE: If I had more time, I think I would look into a Linq way of doing this (Distinct + Sum perhaps?)
                foreach (var word in words)
                {
                    // if this isn't the first time in i.e. previousWord is empty,
                    // OR the previousWord var is not equal to the current word item
                    // we need to process it
                    if (string.IsNullOrEmpty(previousWord) || previousWord != word)
                    {
                        // get the number of times the word appears in the array using the Linq Count() method
                        var currentWordCount = words.Where(w => w == word).Count();
                        // add this word to the list of counted words
                        countedWords.Add(new WordCountResult(word, currentWordCount));
                    }
                    // set the previousWord var to the current word item and continue looping
                    previousWord = word;
                }
                return countedWords;
            }
            catch(Exception ex)
            {
                // log etc,
                throw;
            }
        }
    }
}
