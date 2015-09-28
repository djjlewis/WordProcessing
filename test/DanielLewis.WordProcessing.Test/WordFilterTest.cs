using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanielLewis.WordProcessing.Core;

namespace DanielLewis.WordProcessing.Test
{
    [TestClass]
    public class WordFilterTest
    {
        [TestMethod]
        public void Should_Filter_Words()
        {
            // Arrange
            var arrayOfWords = new[] { "al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex", "ely", "foul", "here", "hereby", "jig", "jigsaw", "or", "saw", "tail", "tailor", "vex", "we", "weaver" };
            var wordFilter = new WordFilter();

            var expectedResult = "albums, barely, befoul, convex, hereby, jigsaw, tailor, weaver";

            // Act
            var result = wordFilter.FilterWords(arrayOfWords);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_ArgumentNullException_With_Null_Argument()
        {
            // Arrange
            string[] arrayOfWords = null;
            var wordFilter = new WordFilter();

            // Act
            var results = wordFilter.FilterWords(arrayOfWords);

            // Assert
            // should throw
        }
    }
}
