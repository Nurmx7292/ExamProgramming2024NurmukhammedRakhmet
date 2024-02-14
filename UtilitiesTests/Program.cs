using System;
using Utilities;
namespace UtilitiesTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test LongWordsCount
            int longWordsCount1 = StringUtilities.LongWordsCount("Some words to count");
            Console.WriteLine($"LongWordsCount : {longWordsCount1}");

            int longWordsCount2 = StringUtilities.LongWordsCount("The lord of the rings");
            Console.WriteLine($"LongWordsCount2: {longWordsCount2}");

            // Test ToSpinalCase
            string spinalCase1 = StringUtilities.ToSpinalCase("spinal Case Testing");
            Console.WriteLine($"ToSpinalCase1: {spinalCase1}");

            string spinalCase2 = StringUtilities.ToSpinalCase("the LorD OF thE Rings");
            Console.WriteLine($"ToSpinalCase2: {spinalCase2}");

            string pascalCase1 = "hElLo woRlD)".ToPascalCase();
            Console.WriteLine($"ToPascalCase1: {pascalCase1}");

            string pascalCase2 = "the LorD OF thE Rings".ToPascalCase();
            Console.WriteLine($"ToPascalCase2: {pascalCase2}");
        }
    }
}