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
        private MainMenuView _view;

        public MenuController(MainMenuView view)
        {
            _view = view;
        }

        public void StartMenu()
        {
            var selectedComponent = _view.DisplayMenuGetSelection();
            Console.WriteLine($"Выбран компонент: {selectedComponent}");
        }
    }
}
