using System;
using System.Collections.Generic;

namespace SecurityEventLog
{
    class Program
    {
        private static List<string> eventLog = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== ЖУРНАЛ СОБЫТИЙ ИНФОРМАЦИОННОЙ БЕЗОПАСНОСТИ ===");

            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterSuccessfulLogin();
                        break;
                    case "2":
                        RegisterFailedLogin();
                        break;
                    case "3":
                        ShowAllEvents();
                        break;
                    case "4":
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
            Console.WriteLine("1. Зарегистрировать успешный вход пользователя");
            Console.WriteLine("2. Зарегистрировать неудачную попытку входа");
            Console.WriteLine("3. Вывести все записи журнала");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие: ");
        }

        static void RegisterSuccessfulLogin()
        {
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string logEntry = $"[{timestamp}] Попытка входа: пользователь {username} - успех";

            eventLog.Add(logEntry);
            Console.WriteLine("Событие успешно зарегистрировано!");
        }

        static void RegisterFailedLogin()
        {
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string logEntry = $"[{timestamp}] Попытка входа: пользователь {username} - неудача";

            eventLog.Add(logEntry);
            Console.WriteLine("Событие успешно зарегистрировано!");
        }

        static void ShowAllEvents()
        {
            Console.WriteLine("=== ВСЕ ЗАПИСИ ЖУРНАЛА ===");

            if (eventLog.Count == 0)
            {
                Console.WriteLine("Журнал пуст.");
                return;
            }

            for (int i = 0; i < eventLog.Count; i++)
            {
                Console.WriteLine(eventLog[i]);
            }
        }
    }
}