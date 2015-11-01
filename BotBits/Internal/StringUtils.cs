using System;

namespace BotBits
{
    internal class StringUtils
    {
        /// <summary>
        ///     Converts the given decimal number to the numeral system with the
        ///     specified radix (in the range [2, 36]).
        /// </summary>
        /// <param name="decimalNumber">The number to convert.</param>
        /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int bitsInLong = 64;
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + digits.Length);

            if (decimalNumber == 0)
                return "0";

            var index = bitsInLong - 1;
            var currentNumber = Math.Abs(decimalNumber);
            var charArray = new char[bitsInLong];

            while (currentNumber != 0)
            {
                var remainder = (int) (currentNumber%radix);
                charArray[index--] = digits[remainder];
                currentNumber = currentNumber/radix;
            }

            var result = new string(charArray, index + 1, bitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        public static string Rot13(string input)
        {
            var array = input.ToCharArray();
            for (var i = 0; i < array.Length; i++)
            {
                var number = (int) array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char) number;
            }
            return new string(array);
        }
    }
}