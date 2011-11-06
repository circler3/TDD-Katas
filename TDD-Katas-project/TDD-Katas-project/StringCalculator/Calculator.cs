﻿using System;
using System.Linq;

namespace TDD_Katas_project.StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : GetSum(numbers);
        }

        private static int GetSum(string numbers)
        {
            var delimiter = GetPossibleDelimiter(numbers);
            var newnumbers = numbers;

            if (HasSpecificDelimiter(numbers)) //for specific delimiters
            {
                delimiter = GetSpecificDelimiter(numbers);
                newnumbers = GetSpecificNumbers(numbers);
            }

            return ContainsAny(numbers, delimiter) ? newnumbers.Split(delimiter.ToCharArray()).Sum(n => ParseToInt(n)) : ParseToInt(newnumbers);

        }

        private static bool HasSpecificDelimiter(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static string GetPossibleDelimiter(string numbers)
        {
            return ",\n";
        }
        private static string GetSpecificDelimiter(string numbers)
        {
            return numbers.Substring(2, numbers.IndexOf("\n") - 2);
        }
        private static string GetSpecificNumbers(string numbers)
        {
            //var num = numbers.Substring(numbers.IndexOf("//"),numbers.Length-numbers.IndexOf("//"));
            ////var startIndex = numbers.IndexOf("\n");
            ////return numbers.Substring(numbers.Length - (numbers.IndexOf("\n") + 1));
            //return num.Substring(num.IndexOf("\n",num.Length-num.IndexOf("\n")));
            return numbers.Substring(numbers.IndexOf("\n") + 1, numbers.Length - numbers.IndexOf("\n") - 1);
        }
        private static int ParseToInt(string n)
        {
            var result = IsGreaterThanThousand(Convert.ToInt32(n)) ? 0 : (Convert.ToInt32(string.IsNullOrEmpty(n) ? "0" : n));
            VelidateNumbersArePerRule(result);

            return result;
        }

        private static bool IsGreaterThanThousand(int nn)
        {
            return nn > 1000;
        }


        private static bool ContainsAny(string input, string getPossibleDelimiters)
        {
            return getPossibleDelimiters.ToCharArray().Any(input.Contains);
        }

        private static void VelidateNumbersArePerRule(int number)
        {
            if (number < 0)
                throw new ArgumentException(string.Format("string contains [{0}], which does not meet rule. entered number should not negative.", number));
        }
    }
}
