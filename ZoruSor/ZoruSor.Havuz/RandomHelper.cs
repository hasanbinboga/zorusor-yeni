using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZoruSor.Lib
{
    /// <summary>
	/// Helper class for generating random values
	/// </summary>
	public static class RandomHelper
    {
        private static readonly Random RandomSeed = new Random();

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="max">max char value</param>
        /// <param name="min">min char value</param>
        /// <returns>Random string</returns>
        public static char RandomChar(char min, char max)
        {
            return (char)RandomNumber(min, max);
        }

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, bool lowerCase)
        {
            // StringBuilder is faster than using strings (+=)
            StringBuilder randStr = new StringBuilder(size);

            // Ascii start position (65 = A / 97 = a)
            int start = (lowerCase) ? 97 : 65;

            // Add random chars
            for (var i = 0; i < size; i++)
                randStr.Append((char)(26 * RandomSeed.NextDouble() + start));

            return randStr.ToString();
        }

        /// <summary>
        /// Returns a random number.
        /// </summary>
        /// <param name="minimal">Minimal result</param>
        /// <param name="maximal">Maximal result</param>
        /// <returns>Random number</returns>
        public static int RandomNumber(int minimal, int maximal)
        {
            maximal++;
            int i = 0, sonuc;
            do
            {
                sonuc = RandomSeed.Next(minimal, maximal);
                i++;
            } while (i < 10);
            return sonuc;
        }

        /// <summary>
        /// Returns a random number.
        /// </summary>
        /// <param name="minimal">Minimal result</param>
        /// <param name="maximal">Maximal result</param>
        /// <param name="step">incremental step</param>
        /// <returns>Random number</returns>
        public static int RandomNumber(int minimal, int maximal, int step)
        {
            var range = maximal - minimal;
            var steps = 1 + range/step;
            maximal++;
            int i = 0, sonuc;
            do
            {
                sonuc = minimal + step * RandomSeed.Next(steps);
                i++;
            } while (i < 10);
            return sonuc;
        }

        public static int RandomDifferentNumber(int minimal, int maximal, int currentVal)
        {
            maximal++;

            var newId = currentVal;
            int i = 0;
            while (newId == currentVal)
            {

                do
                {
                    newId = RandomSeed.Next(minimal, maximal);
                    i++;
                } while (i < 10);
            }
            return newId;
        }

        public static int RandomDifferentNumber(int minimal, int maximal, int currentVal, bool isSmallThan)
        {
            maximal++;

            var newId = currentVal;
            int i = 0;
            if (isSmallThan)
            {
                do
                {

                    do
                    {
                        newId = RandomSeed.Next(minimal, maximal);
                        i++;
                    } while (i < 10);
                } while (newId >= currentVal);

            }
            else
            {
                do
                {
                    do
                    {
                        newId = RandomSeed.Next(minimal, maximal);
                        i++;
                    } while (i < 10);
                } while (newId <= currentVal);
            }

            return newId;
        }

        public static int RandomDifferentNumber(int minimal, int maximal, int[] currentVal)
        {
            maximal++;

            if (currentVal.Length == 0)
            {
                return RandomSeed.Next(minimal, maximal);
            }

            var newId = currentVal[0];
            while (currentVal.Contains(newId))
            {
                var i = 0;
                do
                {
                    newId = RandomSeed.Next(minimal, maximal);
                    i++;
                } while (i < 10);
            }
            return newId;
        }

        public static int[] RandomDifferentNumbers(int minimal, int maximal, int numCount, int[][] currentVal)
        {
            maximal++;
            var newList = new List<int>();
            do
            {

                for (int i = 0; i < numCount; i++)
                {
                    newList.Add(RandomDifferentNumber(minimal, maximal - 1, newList.ToArray()));
                }
            } while (currentVal.Contains(newList.ToArray()));
            return newList.ToArray();
        }

        /// <summary>
        /// Returns a random boolean value
        /// </summary>
        /// <returns>Random boolean value</returns>
        public static bool RandomBool()
        {
            return (RandomSeed.NextDouble() > 0.5);
        }

        /// <summary>
        /// Returns a random color
        /// </summary>
        /// <returns></returns>
        public static System.Drawing.Color RandomColor()
        {
            return System.Drawing.Color.FromArgb(
                RandomSeed.Next(256),
                RandomSeed.Next(256),
                RandomSeed.Next(256)
            );
        }

    }
}
