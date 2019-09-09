using System;
using System.Collections.Generic;
using System.Text;

namespace LexicogTree
{
    public static class HelperClass
    {
        /// <summary>
        /// Generate a random string
        /// </summary>
        /// <param name="size">Number of character in string</param>
        /// <param name="lowerCase">Set character in lower case</param>
        /// <returns></returns>
        public static string RandomString(int size, bool lowerCase)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
