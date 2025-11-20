using System;

namespace LoginPasswordCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            const string correctLogin = "Qwerty";
            const string correctPassword = "1234";

            int attempts = 3;
            bool accessGranted = false;

            Console.WriteLine("=== ПРОВЕРКА ЛОГИНА И ПАРОЛЯ ===");

            for (int i = attempts; i > 0; i--)
            {
                Console.WriteLine("Попытка {0} из {1}", attempts - i + 1, attempts);

                Console.Write("Логин: ");
                string login = Console.ReadLine();

                Console.Write("Пароль: ");
                string password = Console.ReadLine();

                if (login == correctLogin && password == correctPassword)
                {
                    Console.WriteLine("Доступ разрешен!");
                    accessGranted = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль!");

                    if (i > 1)
                    {
                        Console.WriteLine("Осталось попыток: {0}", i - 1);
                    }
                    else
                    {
                        Console.WriteLine("Доступ запрещен!");
                    }
                }
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}