namespace Problem_1
{
    internal static class Validator
    {
        public static bool IsValidCompressedString(string s)
        {
            if (s == string.Empty)
            {
                return true;
            }

            if (char.IsDigit(s[0]))
            {
                return false;
            }

            char? lastLetter = null;
            bool isFirstDigit = true;

            for (int i = 0; i < s.Length; i++)
            {
                char currentSymbol = s[i];

                if (char.IsAsciiLetterLower(currentSymbol))
                {
                    if (SameLettersConsecutively(currentSymbol, lastLetter))
                    {
                        return false;
                    }

                    lastLetter = currentSymbol;
                    isFirstDigit = true;
                    continue;
                }

                if (char.IsDigit(currentSymbol))
                {
                    if (GroupSizeStartsWithZero(currentSymbol, isFirstDigit))
                    {
                        return false;
                    }

                    if (GroupSizeEqualsOne(isFirstDigit, currentSymbol, s, i))
                    {
                        return false;
                    }

                    isFirstDigit = false;
                    continue;
                }

                return false;
            }

            return true;
        }

        private static bool SameLettersConsecutively(char currentSymbol, char? lastLetter)
        {
            return currentSymbol == lastLetter;
        }

        private static bool GroupSizeStartsWithZero(char currentSymbol, bool isFirstDigit)
        {
            return currentSymbol == '0' && isFirstDigit;
        }

        private static bool GroupSizeEqualsOne(bool isFirstDigit, char currentSymbol, string s, int currentIndex)
        {
            return isFirstDigit
                && currentSymbol == '1'
                && (currentIndex == s.Length - 1 || char.IsAsciiLetterLower(s[currentIndex + 1]));
        }

        public static bool IsValidStringToCompress(string s)
        {
            return s.All(char.IsAsciiLetterLower);
        }
    }
}
