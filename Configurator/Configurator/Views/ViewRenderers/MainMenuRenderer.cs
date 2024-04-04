using Configurator.Models.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Renderers
{
    /// <summary>
    /// Класс, который реализует интерфейс IMenuRenderer
    /// Содержит логику для отрисовки начального меню выбора
    /// </summary>
    class MainMenuRenderer : IMenuRenderer
    {
        /// <summary>
        /// Отображает меню выбора типа подбираемого комплектующего.
        /// </summary>
        /// <param name="selectedIndex">Индекс выбранного компонента.</param>
        public void RenderMenu(int selectedIndex)
        {
            Console.Clear();

            Console.WriteLine("Выбрать комплектующее:");
            Console.WriteLine();

            foreach (ComponentType component in Enum.GetValues(typeof(ComponentType)))
            {
                if ((int)component == selectedIndex)
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
