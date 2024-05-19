using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.UserInput
{
    public static class ConsoleInput
    {
        public static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            string? value;
            while ((value = Console.ReadLine()) == null)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста попробуйте снова.");
                Console.WriteLine("Строка не должна быть пустой.");
            }
            return value;
        }

        public static int ReadInteger(string prompt)
        {
            Console.WriteLine(prompt);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Неверный ввод. Пожалуйста попробуйте снова.");
                Console.WriteLine("Значение должно быть целочисленным.");
            }
            return value;
        }

        public static bool ReadBoolean(string prompt)
        {
            Console.WriteLine(prompt);
            bool value;
            while (!bool.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Неверный ввод. Пожалуйста попробуйте снова.");
                Console.WriteLine("Значение должно быть true/false.");
            }
            return value;
        }

        public static decimal ReadDecimal(string prompt)
        {
            Console.WriteLine(prompt);
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Неверный ввод. Пожалуйста попробуйте снова.");
                Console.WriteLine("Значение должно быть десятичным числом.");
            }
            return value;
        }
    }
}
