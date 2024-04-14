using Configurator.Models.Components;
using Configurator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Controllers
{
    internal class ConsoleMenuController
    {
        private MainMenuConsoleView _view; // Поле для работы с представлением основного меню

        /// <summary>
        /// Конструктор класса ConsoleMenuController.
        /// </summary>
        /// <param name="view">Экземпляр класса MainMenuConsoleView для представления меню.</param>
        public ConsoleMenuController(MainMenuConsoleView view)
        {
            _view = view;
        }

        public void StartMenu()
        {
            // Получение выбранного компонента из представления меню
            var selectedComponent = _view.DisplayMenuGetSelection();

            // Вывод выбранного компонента в консоль(заглушка)
            Console.WriteLine($"Выбран компонент: {selectedComponent}");
        }
    }
}
