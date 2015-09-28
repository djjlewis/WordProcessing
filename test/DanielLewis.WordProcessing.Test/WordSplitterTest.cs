using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanielLewis.WordProcessing.Core;

namespace DanielLewis.WordProcessing.Test
{
    [TestClass]
    public class WordAplitterTest
    {
        [TestMethod]
        public void Should_Split_Words()
        {
            // Arrange
            var text = "This is some text, with punctuation!\n It also has new lines etc. it also has this twice in different case.";
            var wordSplitter = new WordSplitter();

            var expectedLength = 20;

            // Act
            var results = wordSplitter.SplitWordsAndSort(text);

            // Assert

            Assert.AreEqual(expectedLength, results.Length);
        }

        [TestMethod]
        public void Should_Split_Words_Ignoring_Punctuation()
        {
            // Arrange
            var text = ". , ( ) ! : ; ' ` ... ,,,, \n\n \r\n ? ";
            var wordSplitter = new WordSplitter();

            var expectedLength = 0;

            // Act
            var results = wordSplitter.SplitWordsAndSort(text);

            // Assert

            Assert.AreEqual(expectedLength, results.Length);
        }
    }
}
