using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CollectionsManipulations.Tests
{
    public class SequenceTests
    {
        [TestCase("(()", ExpectedResult = false)]
        [TestCase("(()))", ExpectedResult = false)]
        [TestCase("(())", ExpectedResult = true)]
        [TestCase("([])", ExpectedResult = true)]
        [TestCase("({})", ExpectedResult = true)]
        [TestCase("({()})", ExpectedResult = true)]
        [TestCase("({([)])}", ExpectedResult = false)]
        [TestCase("({", ExpectedResult = false)]
        public bool CheckParenthesesPlacementTest(string inputString)
            => Sequence.CheckParenthesesPlacement(inputString);

        [Test]
        public void CheckParenthesesPlacement_InputStringIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sequence.CheckParenthesesPlacement(null));
        }

        [Test]
        public void CheckParenthesesPlacement_InputStringIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequence.CheckParenthesesPlacement(""));
        }

        [Test]
        public void CountUniqueWords_InputStringIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sequence.CountUniqueWords(null, ' '));
        }

        [Test]
        public void CountUniqueWords_InputStringIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequence.CountUniqueWords("", ' '));
        }

        [Test]
        public void CountUniqueWordsTest_AmeetsTwoTimes_Dictionary()
        {
            var input = "once upon a time a";
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                ["once"] = 1,
                ["upon"] = 1,
                ["a"] = 2,
                ["time"] = 1
            };

            var actual = Sequence.CountUniqueWords(input, ' ');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountUniqueWordsTest_WordsDifferInLetterCases_Dictionary()
        {
            var input = "once upon a time A Time new NEW once a";
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                ["once"] = 2,
                ["upon"] = 1,
                ["a"] = 2,
                ["time"] = 1,
                ["A"] = 1,
                ["Time"] = 1,
                ["new"] = 1,
                ["NEW"] = 1
            };

            var actual = Sequence.CountUniqueWords(input, ' ');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountUniqueWordsTest_StringContainsSymbols_Dictionary()
        {
            var input = "once, upon a time?A Timenew NEW once/ a";
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                ["once,"] = 1,
                ["upon"] = 1,
                ["a"] = 2,
                ["time?A"] = 1,
                ["Timenew"] = 1,
                ["NEW"] = 1,
                ["once/"] = 1,
            };

            var actual = Sequence.CountUniqueWords(input, ' ');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountUniqueWordsTest_SplitterIsA_Dictionary()
        {
            var input = "once, aupon a time?ATimenewNEWaonce/aonce,aonce, ";
            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                ["once, "] = 2,
                ["upon "] = 1,
                [" time?ATimenewNEW"] = 1,
                ["once/"] = 1,
                ["once,"] = 1,
            };

            var actual = Sequence.CountUniqueWords(input, 'a');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindUniqueWords_InputStringIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Sequence.FindUniqueWords(null, ' '));
        }

        [Test]
        public void FindUniqueWords_InputStringIsEmpty_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequence.FindUniqueWords("", ' '));
        }

        [Test]
        public void FindUniqueWordsTest_WordsDifferInLetterCases_IEnumerableStrings()
        {
            var input = "once upon a time A Time new NEW once a";
            IEnumerable<string> expected = new List<string>() { "once", "upon", "a", "time", "new" };

            var actual = Sequence.FindUniqueWords(input, ' ');
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindUniqueWordsTest_OrdinaryWordsInLetterCases_IEnumerableStrings()
        {
            var input = "once upon a time im new";
            IEnumerable<string> expected = new List<string>() { "once", "upon", "a", "time", "im", "new" };

            var actual = Sequence.FindUniqueWords(input, ' ');
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, ExpectedResult = 3)]
        [TestCase(10, ExpectedResult = 5)]
        [TestCase(6, ExpectedResult = 5)]
        [TestCase(7, ExpectedResult = 7)]
        [TestCase(13, ExpectedResult = 11)]
        [TestCase(41, ExpectedResult = 19)]
        public int SimulateJosephusProblemTests(int n)
            => Sequence.SimulateJosephusProblem(n);

        [Test]
        public void SimulateJosephusProblem_InputNumberLessThanZero_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Sequence.SimulateJosephusProblem(-9));
        }

        [Test]
        public void SimulateJosephusProcess_NumberIs8_Sequnce()
        {
            int n = 8;
            IEnumerable<int> expected = new List<int>() { 2, 4, 6, 8, 3, 7, 5 };
            IEnumerable<int> actual = Sequence.SimulateJosephusProcess(n);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SimulateJosephusProcess_NumberIs9_Sequnce()
        {
            int n = 9;
            IEnumerable<int> expected = new List<int>() { 2, 4, 6, 8, 1, 5, 9, 7 };
            IEnumerable<int> actual = Sequence.SimulateJosephusProcess(n);

            Assert.AreEqual(expected, actual);
        }

    }
}
