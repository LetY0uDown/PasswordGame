using System;

namespace PasswordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Приветствие
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t\t\tДобро пожаловать в игру The Password Game!");
            Console.ResetColor();

            Console.WriteLine("\nЕё правила просты:");
            Console.WriteLine("\tВам необходимо угадать пароль, состоящий из случайного трёхзначного числа.");
            Console.WriteLine("\tИгра будет сообщать, если введённое вами число больше или меньше чем данный пароль");

            Console.WriteLine("\nВыберите режим игры:");
            Console.WriteLine("1. Неограниченый - 1000 попыток;");
            Console.WriteLine("2. Лёгкий - 15 попыток;");
            Console.WriteLine("3. Средний - 10 попыток;");
            Console.WriteLine("4. Сложный - 7 попыток;");
            Console.WriteLine("5. Эксперт - 4 попытки;");
            Console.WriteLine("6. Фортуна - 1 попытка");
            Console.Write("\nВведите номер режима >> ");
#endregion

            int.TryParse(Console.ReadLine(), out int mode);
            int[] attempts = { 1000, 15, 10, 7, 4, 1 };
            int attemptAmount, attemptCount = 0, closestAttempt = 1000;
            try
            {
                attemptAmount = attempts[mode - 1];
                Console.WriteLine($"Режим выбран! Попыток: {attemptAmount}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Режим выбран неверно! Попробуйте ещё раз");
                return;
            }

            Console.WriteLine("\n\t\t\t\tУдачи!");
            Console.WriteLine("Нажмите любую клавишу чтобы играть...");
            Console.ReadKey();
            Console.Clear();

            Random rand = new Random();
            int password = rand.Next(100, 1000);

            while(attemptAmount > 0)
            {
                attemptAmount--;
                attemptCount++;

                Console.Write("\nВведите пароль >> ");
                int.TryParse(Console.ReadLine(), out int passTry);

                if(passTry.ToString().Length != 3)
                {
                    Console.WriteLine("Вы ввели не трёхзначное число!");
                    Console.WriteLine($"В следующий раз будьте внимательны!\nПопыток осталось: {attemptAmount}");
                    continue;
                }

                if (Math.Abs(password - passTry) < closestAttempt)
                    closestAttempt = passTry;

                if (passTry == password)
                {
                    Console.Clear();
                    Console.Write($"\nВерно, вы угадали пароль! Им было число {password}");
                    Console.WriteLine($"\nПопыток потрачено: {attemptCount}\nПопыток осталось: {attemptAmount}");
                    return;
                }
                else if (passTry < password)
                {
                    Console.WriteLine("Неверно! Пароль больше чем введённое число");
                    Console.WriteLine($"Попыток осталось: {attemptAmount}");
                }
                else if (passTry > password)
                {
                    Console.WriteLine("Неверно! Пароль меньше чем введённое число");
                    Console.WriteLine($"Попыток осталось: {attemptAmount}");
                }
            }

            Console.WriteLine("\nВам не удалось угадать пароль. Попыток больше нет. Сожалею, вы проиграли");
            Console.WriteLine($"\nПаролем было число {password}");
            Console.WriteLine($"Ближайшая попытка - число {closestAttempt}\n");
        }
    }
}
