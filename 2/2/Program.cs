using System;

namespace PasswordStrengthCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ПРОВЕРКА НАДЕЖНОСТИ ПАРОЛЯ ===");
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            bool isStrong = CheckPasswordStrength(password);

            if (isStrong)
            {
                Console.WriteLine("Пароль надежный");
            }
            else
            {
                Console.WriteLine("Пароль слабый");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static bool CheckPasswordStrength(string password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Пароль должен содержать не менее 8 символов");
                return false;
            }

            bool hasDigit = false;
            bool hasUpper = false;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }

                if (hasDigit && hasUpper)
                {
                    break;
                }
            }

            if (!hasDigit)
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру");
            }
            if (!hasUpper)
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну заглавную латинскую букву");
            }

            return hasDigit && hasUpper;
        }
    }
}