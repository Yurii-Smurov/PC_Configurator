using Configurator.Models.Components;
using Configurator.Views.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class MainMenuConsoleView
    {
        private readonly IMenuRenderer _menuRenderer;

        public MainMenuConsoleView (IMenuRenderer menuRenderer)
        {
            _menuRenderer = menuRenderer;
        }

        /// <summary>
        /// Метод, который отображает меню и позволяет пользователю сделать выбор.
        /// </summary>
        /// <returns>Тип выбранного компонента.</returns>
        public ComponentType DisplayMenuGetSelection()
        {
            // Инициализация индекса выбранного компонента
            int index = 0;
            // Цикличная отрисовка меню, обработка действий пользователя
            while (true)
            {
                _menuRenderer.RenderMenu(index);
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
    }
}
