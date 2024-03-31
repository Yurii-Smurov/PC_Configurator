using Configurator.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    internal class MainMenuView
    {
        public ComponentType DisplayMenuGetSelection()
        {
            int index = 0;

            while (true)
            {
                DrawMenu(index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < Enum.GetNames(typeof(ComponentType)).Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        return (ComponentType)index;
                }
            }
        }

        private void DrawMenu(int index)
        {

            Console.Clear();

            Console.WriteLine("Выбрать комплектующее:");
            Console.WriteLine();

            foreach (ComponentType component in Enum.GetValues(typeof(ComponentType)))
            {
                if ((int)component == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(component.ToString());
                Console.ResetColor();
            }
            Console.WriteLine();
            
        }
    }
}
