using GuessNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Concrete
{
    internal class CheckNumber : IRunnable
    {
        private IGenerator generator;
        private ISettings settings;
        private IDialogue<string> dialogue;
        private int TheNumber;
        private int Tries;
        public CheckNumber(IGenerator _generator, ISettings _settings, IDialogue<string> _dialogue)
        {
            generator = _generator;
            settings = _settings;
            dialogue = _dialogue;
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        public void Run()
        {
            TheNumber = generator.Generate(settings.Min, settings.Max);
            Tries = settings.Amount;
            dialogue.Write($"Угадайте число!\nМинимальное значение: {settings.Min}\nМаксимальное значение: {settings.Max}\nКоличество попыток: {settings.Amount}\nВведите число...");
            while (Tries > 0)
            {
                string result = "Введите корректное число в рамках заданного диапазона!";
                switch (Check(dialogue.Read()))
                {
                    case CheckResult.Less:
                        Tries--;
                        result = $"это число меньше загаданного. Осталось попыток: {Tries}";
                        break;
                    case CheckResult.Greater:
                        Tries--;
                        result = $"это число больше загаданного. Осталось попыток: {Tries}";
                        break;
                    case CheckResult.Equal:
                        result = "Вы угадали!";
                        Tries = 0;
                        break;
                    default:
                        break;
                }
                dialogue.Write(result);
            }
        }

        /// <summary>
        /// Проверяет строку относительно загаданного числа
        /// </summary>
        /// <param name="value">строка для проверки</param>
        /// <returns>Error если нельзя прочитать, как число, или число выходит за рамки заданного диапазона;
        /// Equal если строка равна заданному числу;
        /// Less если строка меньше заданного числа;
        /// Greater если строка больше заданного числа</returns>
        public CheckResult Check(string? value)
        {
            int? number = string.IsNullOrWhiteSpace(value) || !int.TryParse(value, out int num) ? null : num;
            if (!number.HasValue || number < settings.Min || number > settings.Max) return CheckResult.Error;
            if (number == TheNumber) return CheckResult.Equal;
            return number < TheNumber ? CheckResult.Less : CheckResult.Greater;
        }

        public enum CheckResult
        {
            Error,
            Equal,
            Less,
            Greater
        }
    }
}
