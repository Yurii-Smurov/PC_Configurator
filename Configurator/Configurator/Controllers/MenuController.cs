using Configurator.Models.Components;
using Configurator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Controllers
{
    internal class MenuController
    {
        private MainMenuView _view; // Поле для работы с представлением основного меню

        /// <summary>
        /// Конструктор класса MenuController.
        /// </summary>
        /// <param name="view">Экземпляр класса MainMenuView для представления меню.</param>
        public MenuController(MainMenuView view)
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
