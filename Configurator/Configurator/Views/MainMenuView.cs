using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class MainMenuView : IView
    {
        private ViewController _viewController;

        public MainMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Главная страница");
        }
    }
}
