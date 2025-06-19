using System.Text;

namespace Problem_1
{
    internal static class Decompressor
    {
        public static string Decompress(string compressedString)
        {
            if (compressedString == string.Empty)
            {
                return string.Empty;
            }

            char? currentGroupSymbol = null;
            int currentGroupSizeCounter = -1;

            StringBuilder decompressedStringBuilder = new();

            foreach (var currentSymbol in compressedString)
            {
                if (char.IsDigit(currentSymbol))
                {
                    byte digit = Utils.ConvertDigitCharToByte(currentSymbol);
                    currentGroupSizeCounter = currentGroupSizeCounter * 10 + digit;

                    continue;
                }

                AppendDecompressedGroup(decompressedStringBuilder, currentGroupSymbol, currentGroupSizeCounter);

                currentGroupSymbol = currentSymbol;
                currentGroupSizeCounter = 0;
            }

            AppendDecompressedGroup(decompressedStringBuilder, currentGroupSymbol, currentGroupSizeCounter);

            return decompressedStringBuilder.ToString();
        }

        private static void AppendDecompressedGroup(StringBuilder decompressedStringBuilder, char? currentGroupSymbol, int currentGroupSizeCounter)
        {
            if (currentGroupSymbol is null)
            {
                return;
            }

            int currentGroupActualSize = currentGroupSizeCounter == 0
                ? 1
                : currentGroupSizeCounter;

            char groupSymbol = (char)currentGroupSymbol;
            string decompressedGroup = new string(groupSymbol, currentGroupActualSize);

            decompressedStringBuilder.Append(decompressedGroup);
        }
    }
}
