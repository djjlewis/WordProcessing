using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielLewis.WordProcessing.Core
{
    /// <summary>
    /// Class to store a Word and how many occurences are in the text
    /// (Could have used a Dictionary<string, int> but sometimes explicit 
    /// classes are easier to work with, understand and more maintainable...
    /// </summary>
    public class WordCountResult
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public WordCountResult(string word, int count)
        {
            Word = word;
            Count = count;
        }
    }
}
