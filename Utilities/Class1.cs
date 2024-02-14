namespace Utilities
{
    public static class StringUtilities
    {
        public static int LongWordsCount(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Can`t be null or empty.");
            }

            string[] words = input.Split(' ');
            return words.Count(word => word.Length > 2);
        }

        public static string ToSpinalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Can`t be null or empty.");
            }

            string[] words = input.Split(' ');
            string spinalCase = string.Join('-', words.Select(word => word.ToLower()));
            return spinalCase;
        }
    }

    public static class StringExtensions
    {
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            string[] words = input.Split(' ');
            string pascalCase = string.Concat(words.Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            return pascalCase;
        }
    }
}
