using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerals
{
    class Program
    {
        private static Dictionary<string, int> numerals = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            numerals.Add("CM", 900);
            numerals.Add("CD", 400);
            numerals.Add("XC", 90);
            numerals.Add("XL", 40);
            numerals.Add("IX", 9);
            numerals.Add("IV", 4);
            numerals.Add("M", 1000);
            numerals.Add("D", 500);
            numerals.Add("C", 100);
            numerals.Add("L", 50);
            numerals.Add("X", 10);
            numerals.Add("V", 5);
            numerals.Add("I", 1);

            ToInt("DCXLVIII");
            ToRoman(999);
            Console.ReadLine();   
        }
        static void ToInt(string romanNumeral)
        {
            int hinduArabic = 0;
            string unconverted = romanNumeral;

            foreach(KeyValuePair<string, int> numeral in numerals)
            {
                int prevLength = unconverted.Length;
                unconverted = unconverted.Replace(numeral.Key, "");
                int numeralCount = (prevLength - unconverted.Length) / numeral.Key.Length;
                hinduArabic += numeralCount * numeral.Value;
                if (unconverted.Length == 0) break; 
            }
            Console.WriteLine(hinduArabic);
        }

        static void ToRoman(int hinduArabic)
        {
            if (hinduArabic < 1)
            {
                throw new ArgumentOutOfRangeException("Roman numerals cannot be zero or negative");
            } else if (hinduArabic > 3888)
            {
                throw new ArgumentOutOfRangeException("This application does not support bar numerals, max value is 3888");
            }
            string romanNumeral = "";
            int unconverted = hinduArabic;

            var descendingNumerals = numerals.OrderByDescending(f => f.Value);

            foreach (KeyValuePair<string, int> numeral in descendingNumerals)
            {
                int numeralOccurences = unconverted / numeral.Value;
                romanNumeral += string.Concat(Enumerable.Repeat(numeral.Key, numeralOccurences));
                unconverted -= numeralOccurences * numeral.Value;
                if (unconverted == 0) break;
            }
            Console.WriteLine(romanNumeral);
        }
    }
}
