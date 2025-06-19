using System.Text;

namespace Problem_1
{
    internal static class Compressor
    {
        public static string Compress(string uncompressedString)
        {
            if (uncompressedString == string.Empty)
            {
                return string.Empty;
            }

            char currentGroupSymbol = uncompressedString.First();
            int currentGroupSize = 0;

            StringBuilder compressedStringBuilder = new();

            foreach (var currentSymbol in uncompressedString)
            {
                if (currentSymbol == currentGroupSymbol)
                {
                    ++currentGroupSize;
                    continue;
                }

                AppendCompressedGroup(compressedStringBuilder, currentGroupSymbol, currentGroupSize);

                currentGroupSymbol = currentSymbol;
                currentGroupSize = 1;
            }

            AppendCompressedGroup(compressedStringBuilder, currentGroupSymbol, currentGroupSize);

            return compressedStringBuilder.ToString();
        }

        private static void AppendCompressedGroup(StringBuilder compressedStringBuilder, char currentGroupSymbol, int currentGroupSize)
        {
            compressedStringBuilder.Append(currentGroupSymbol);

            if (currentGroupSize > 1)
            {
                compressedStringBuilder.Append(currentGroupSize);
            }
        }
    }
}
