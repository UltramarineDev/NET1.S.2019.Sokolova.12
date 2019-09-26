using System;
using System.Collections.Generic;

namespace CollectionsManipulations
{
    public class Sequence
    {
        private static Dictionary<char, char> GetSymbols() => new Dictionary<char, char>
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '['
        };

        /// <summary>
        /// Checks the parentheses placement.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>true if placement is correct, false otherwise</returns>
        /// <exception cref="ArgumentNullException">Input string is null. - inputString</exception>
        /// <exception cref="ArgumentException">Input string is empty. - inputString</exception>
        public static bool CheckParenthesesPlacement(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException("Input string is null.", nameof(inputString));
            }

            if (inputString.Length == 0)
            {
                throw new ArgumentException("Input string is empty.", nameof(inputString));
            }

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> symbols = GetSymbols();
            foreach (var symbol in inputString)
            {
                if (symbols.TryGetValue(symbol, out char value))
                {
                    if (stack.Count != 0 && stack.Peek() == value)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(symbol);
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the unique words.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="splitter">The splitter.</param>
        /// <returns>IEnumerable of unique words</returns>
        /// <exception cref="ArgumentNullException">Input string is null. - inputString</exception>
        /// <exception cref="ArgumentException">Input string is empty. - inputString</exception>
        public static IEnumerable<string> FindUniqueWords(string inputString, char splitter)
        {
            CheckInputValues(inputString);

            string[] arrayOfInputString = inputString.ToLower().Split(splitter);

            var dictionary = CreateDictionaryOfUniqueWords(arrayOfInputString);

            foreach (var word in dictionary)
            {
                yield return word.Key;
            }
        }

        /// <summary>
        /// Counts the unique words.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <param name="splitter">The splitter.</param>
        /// <returns>Dictionary of unique words and frequency of it's occurrence</returns>
        /// <exception cref="ArgumentNullException">Input string is null. - inputString</exception>
        /// <exception cref="ArgumentException">Input string is empty. - inputString</exception>
        public static IDictionary<string, int> CountUniqueWords(string inputString, char splitter)
        {
            CheckInputValues(inputString);

            string[] arrayOfInputString = inputString.Split(splitter);

            return CreateDictionaryOfUniqueWords(arrayOfInputString);
        }

        private static void CheckInputValues(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException("Input string is null.", nameof(inputString));
            }

            if (inputString.Length == 0)
            {
                throw new ArgumentException("Input string is empty.", nameof(inputString));
            }
        }

        private static Dictionary<string, int> CreateDictionaryOfUniqueWords(string[] arrayOfInputString)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var word in arrayOfInputString)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = 0;
                }

                dictionary[word]++;
            }

            return dictionary;
        }

        /// <summary>
        /// Simulates the josephus problem.
        /// </summary>
        /// <param name="n">The input number</param>
        /// <returns>survived number</returns>
        public static int SimulateJosephusProblem(int n)
        {
            ValidateInputParameters(n);

            int biggestPower = 0;
            for (int i = 0; i < n; i++)
            {
                if (n < Math.Pow(2, i))
                {
                    biggestPower = i - 1;
                    break;
                }
            }

            return 2 * (n - (int)(Math.Pow(2, biggestPower))) + 1;

            #region Old solution 
            return SimulateHelper(n);
            int SimulateHelper(int number)
            {
                if (number == 1)
                {
                    return 1;
                }

                return number % 2 == 0 ? 2 * SimulateHelper(number / 2) - 1 : 2 * SimulateHelper((number - 1) / 2) + 1;
            }
            #endregion
        }

        /// <summary>
        /// Simulates Josephus Process
        /// </summary>
        /// <param name="n">The input number</param>
        /// <returns>ordered sequence of deleted items</returns>
        public static IEnumerable<int> SimulateJosephusProcess(int n)
        {
            ValidateInputParameters(n);
            List<int> sequence = new List<int>();
            sequence.AddRange(CreateSequence(n));

            int starter = 0;

            while (sequence.Count != 1)
            {
                int nextDead = GetNextDeadIndex(sequence, starter);
                yield return sequence[nextDead] + 1;
                sequence.RemoveAt(nextDead);
                starter = nextDead;
            }
        }

        private static int GetNextDeadIndex(List<int> list, int startPosition)
        {
            if (startPosition == list.Count)
            {
                startPosition = 0;
            }

            if (startPosition == list.Count - 1)
            {
                startPosition = -1;
            }

            return ++startPosition;
        }

        private static IEnumerable<int> CreateSequence(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }

        private static void ValidateInputParameters(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("N equals or less than 0.", nameof(n));
            }
        }
    }
}
