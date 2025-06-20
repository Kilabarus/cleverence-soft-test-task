namespace Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                HandleInteractiveMode();
                return;
            }

            HandleCommandLineCall(args);
        }

        private static void HandleInteractiveMode()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - Компрессия строки");
                Console.WriteLine("2 - Декомпрессия строки");
                Console.WriteLine("0 - Выход из программы");
                Console.Write("Ввод: ");

                HashSet<string> menuOptions = ["1", "2", "0"];

                string option = GetValidString(menuOptions.Contains, "Введена неверная строка, повторите ввод: ");

                switch (option)
                {
                    case "1":
                        HandleCompression();
                        break;
                    case "2":
                        HandleDecompression();
                        break;
                    case "0":
                        return;
                }

                Console.WriteLine();
            }
        }

        private static void HandleCompression()
        {
            HandleProcess(
                "Введите строку для компрессии: ",
                Validator.IsValidStringToCompress,
                PrintInvalidStringToCompressMessage,
                Compressor.Compress,
                "Строка после компрессии: "
            );
        }

        private static void HandleDecompression()
        {
            HandleProcess(
                "Введите строку для декомпрессии: ",
                Validator.IsValidCompressedString,
                PrintInvalidStringToDecompressMessage,
                Decompressor.Decompress,
                "Строка после декомпрессии: "
            );
        }

        private static void HandleProcess(
            string initialMessage,
            Predicate<string> validator,
            Action onInvalid,
            Func<string, string> processor,
            string resultMessagePrefix)
        {
            Console.Write(initialMessage);

            string input = GetValidString(validator, onInvalid);
            string result = processor(input);

            Console.WriteLine($"{resultMessagePrefix}{result}");
        }

        private static string GetValidString(Predicate<string> validator, string errorMessage)
        {
            return GetValidString(validator, () => Console.WriteLine(errorMessage));
        }

        private static string GetValidString(Predicate<string> validator, Action? onInvalid = null)
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine("Введенная строка была null, повторите ввод");
                    continue;
                }

                if (!validator(input))
                {
                    onInvalid?.Invoke();
                    continue;
                }

                return input;
            }
        }

        private static void PrintInvalidStringToCompressMessage()
        {
            Console.WriteLine("Введенная строка не валидна, строка может содержать только строчные буквы латинского алфавита");
        }

        private static void PrintInvalidStringToDecompressMessage()
        {
            Console.WriteLine("Введенная строка не валидна, проверьте правильность и повторите попытку");
        }

        private static void HandleCommandLineCall(string[] args)
        {
            if (args.Length != 2)
            {
                PrintInvalidArgsMessage();
                return;
            }

            string key = args[0];
            string stringArgument = args[1];

            if (CommandLineKeys.CompressKeys.Contains(key))
            {
                if (!Validator.IsValidStringToCompress(stringArgument))
                {
                    PrintInvalidStringToCompressMessage();
                    return;
                }

                string compressedString = Compressor.Compress(stringArgument);
                Console.WriteLine(compressedString);

                return;
            }

            if (CommandLineKeys.DecompressKeys.Contains(key))
            {
                if (!Validator.IsValidCompressedString(stringArgument))
                {
                    PrintInvalidStringToDecompressMessage();
                    return;
                }

                string decompressedString = Decompressor.Decompress(stringArgument);
                Console.WriteLine(decompressedString);

                return;
            }

            PrintUnknownKeyMessage();
        }

        private static void PrintInvalidArgsMessage()
        {
            Console.WriteLine("Введено неправильное количество аргументов");
            Console.WriteLine("Вызов программы из командной строки должен сопровождаться ключом и строкой");

            Console.WriteLine("Доступные ключи:");
            PrintAvailableKeys();
        }

        static void PrintUnknownKeyMessage()
        {
            Console.WriteLine("Введен неизвестный ключ, доступные ключи:");
            PrintAvailableKeys();

            Console.WriteLine("Введите один из ключей выше и повторите попытку");
        }

        static void PrintAvailableKeys()
        {
            string compressKeys = string.Join(',', CommandLineKeys.CompressKeys);
            string decompressKeys = string.Join(',', CommandLineKeys.DecompressKeys);

            Console.WriteLine($"Компрессия строки - {compressKeys}");
            Console.WriteLine($"Декомпрессия строки - {decompressKeys}");
        }
    }
}
