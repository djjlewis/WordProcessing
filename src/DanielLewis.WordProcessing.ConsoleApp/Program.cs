using DanielLewis.WordProcessing.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielLewis.WordProcessing.ConsoleApp
{
    class Program
    {
        private static readonly string _fileInputPath = ConfigurationManager.AppSettings["FileInputPath"];

        static void Main(string[] args)
        {
            try
            {
                if (string.IsNullOrEmpty(_fileInputPath.Trim()))
                {
                    throw new ConfigurationErrorsException("Please specify the path to the file input using the FileInputPath in the configuration file.");
                }

                if (!File.Exists(_fileInputPath))
                {
                    throw new FileNotFoundException(string.Format("Could not find file at path '{0}'", _fileInputPath));
                }

                // StreamReader.ReadToEnd is possibly more efficient, but this is only a small text file
                string fileText = File.ReadAllText(_fileInputPath);

                // Split the words from the file into a new string array,
                var wordSplitter = new WordSplitter();
                string[] allWords = wordSplitter.SplitWordsAndSort(fileText);

                // Get the counted words
                var wordCounter = new WordCounter();
                List<WordCountResult> countedWords = wordCounter.CountWords(allWords);

                // show the report on screen
                ShowWordCountReport(countedWords);

                Console.WriteLine();

                // Apply the step-two filter 

                // we only need the unique words and the count, so map them
                // using a linq Select() projection
                string[] uniqueWords = countedWords.Select(s => s.Word).ToArray();
                
                // Get a string of words that match the filter
                var wordFilter = new WordFilter();
                string filteredWords = wordFilter.FilterWords(uniqueWords);

                Console.WriteLine("Words matching the filter:");
                Console.WriteLine(filteredWords);
            }
            catch (Exception ex)
            {
                LogErrorToConsole(ex.Message);
            }

            Console.Write("\nFinished. Press any key to quit...");
            Console.Read();
        }

        private static void ShowWordCountReport(List<WordCountResult> countedWords)
        {
            var colour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Word\t\t\tCount");
            Console.WriteLine("----\t\t\t-----");
            Console.ForegroundColor = colour;

            foreach (var item in countedWords)
            {
                if (item.Word.Length >= 8)
                {
                    Console.WriteLine("{0}\t\t{1}", item.Word, item.Count);
                }
                else
                {
                    Console.WriteLine("{0}\t\t\t{1}", item.Word, item.Count);

                }
            }
        }

        private static void LogErrorToConsole(string message)
        {
            var colour = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred: " + message);
            Console.ForegroundColor = colour;
        }
    }
}
