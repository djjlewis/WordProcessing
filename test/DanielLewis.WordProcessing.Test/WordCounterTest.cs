using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanielLewis.WordProcessing.Core;

namespace DanielLewis.WordProcessing.Test
{
    [TestClass]
    public class WordCounterTest
    {
        [TestMethod]
        public void Should_Count_Words()
        {
            // Arrange
            var arrayOfWords = new[] { "hello", "goodbye", "hello", "goodbye", "hello" };
            var wordCounter = new WordCounter();

            var expectedHellos = 3;
            var expectedGoodbyes = 2;

            // Act
            var results = wordCounter.CountWords(arrayOfWords);

            // Assert

            Assert.AreEqual(expectedHellos, results[0].Count);
            Assert.AreEqual(expectedGoodbyes, results[1].Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_ArgumentNullException_With_Null_Argument()
        {
            // Arrange
            string[] arrayOfWords = null;
            var wordCounter = new WordCounter();

            // Act
            var results = wordCounter.CountWords(arrayOfWords);

            // Assert
            // should throw
        }
    }
}
