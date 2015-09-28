using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielLewis.WordProcessing.Core
{
    /// <summary>
    /// The WordFilter Class has one method, FilterWords which will return a string of 
    /// words that pass the filter
    /// </summary>
    public class WordFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="words">A string array of words to apply the filter to.</param>
        /// <returns>A string of comma delimited words passing the filter, or string.Empty if no matches.</returns>
        public string FilterWords(string[] words)
        {
            // check arguments
            if (words == null)
            {
                throw new ArgumentNullException("words");
            }

            try
            {
                // This will return a list of all possible 6 character combinations of words in the list
                List<string> allCombinations = GetAllWordCombinations(words);

                // This will get a list of the possible 6 character words that can be matched
                var possibleMatches = words.Where(w => w.Length == 6).ToArray();

                // We'll use a string builder as we could be concatenating a lot of strings 
                var sb = new StringBuilder();

                // first we loop through the *possible* correct matches to reduce the 
                // number of iterations
                foreach (var word in possibleMatches)
                {
                    // now we will check this against the list of all word combinations
                    // and see if we get a match
                    var matchedWord = allCombinations.Where(w => w == word).SingleOrDefault();

                    if (!string.IsNullOrEmpty(matchedWord))
                    {
                        sb.Append(word + ", ");
                    }
                }

                // if we had some matches, return a string from the builder
                if (sb.Length > 0)
                {
                    // don't include last comma and space.
                    return sb.ToString(0, sb.Length - 2);
                }
                else // otherwise return an empty string
                {
                    return string.Empty;
                }
            }
            catch(Exception ex)
            {
                // log etc
                throw;
            }
        }

        private List<string> GetAllWordCombinations(string[] words)
        {
            List<string> allCombinations = new List<string>();

            foreach (var word in words)
            {
                GetAllCobminationsForWord(word, words, allCombinations);
            }
            return allCombinations;
        } 

        private void GetAllCobminationsForWord(string word, string[] words, List<string> combinedWords)
        {
            foreach (var item in words)
            {
                if (item != word)
                {
                    var combinedWord = item + word;
                    if (combinedWord.Length == 6)
                    {
                        combinedWords.Add(combinedWord);
                    }
                }
            }
        }
    }
}
