using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ШИФР ЦЕЗАРЯ ===");

            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EncryptText();
                        break;
                    case "2":
                        DecryptText();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void ShowMenu()
        {
            Console.WriteLine("МЕНЮ:");
            Console.WriteLine("1. Зашифровать текст");
            Console.WriteLine("2. Расшифровать текст");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите действие: ");
        }

        static void EncryptText()
        {
            Console.Write("Введите текст для шифрования: ");
            string text = Console.ReadLine();

            Console.Write("Введите сдвиг (целое число): ");
            if (int.TryParse(Console.ReadLine(), out int shift))
            {
                string encrypted = CaesarCipher(text, shift);
                Console.WriteLine("Зашифрованный текст: {0}", encrypted);
            }
            else
            {
                Console.WriteLine("Неверный формат сдвига!");
            }
        }

        static void DecryptText()
        {
            Console.Write("Введите текст для расшифровки: ");
            string text = Console.ReadLine();

            Console.Write("Введите сдвиг (целое число): ");
            if (int.TryParse(Console.ReadLine(), out int shift))
            {
                string decrypted = CaesarCipher(text, -shift);
                Console.WriteLine("Расшифрованный текст: {0}", decrypted);
            }
            else
            {
                Console.WriteLine("Неверный формат сдвига!");
            }
        }

        static string CaesarCipher(string text, int shift)
        {
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c) && IsLatinLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    result[i] = (char)(((c - baseChar + shift) % 26 + 26) % 26 + baseChar);
                }
                else
                {
                    result[i] = c;
                }
            }

            return new string(result);
        }

        static bool IsLatinLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
    }
}