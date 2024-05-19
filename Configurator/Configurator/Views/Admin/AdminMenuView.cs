using Configurator.Views.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Admin
{
    class AdminMenuView : IView
    {

        private ViewController _viewController;

        public AdminMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("Выбери действие администратора:");
                Console.WriteLine("1. Добавить комплектующее");
                Console.WriteLine("2. Удалить комплектующее");

                int choice = ConsoleInput.ReadInteger("Выбор: "); // вызов метода GetChoice и сохранение введенного пользователем значения

                switch (choice)
                {
                    case 1:
                        _viewController.ChangeState(new AddComponentView(_viewController)); // создание экземпляра класса AddComponentView
                        _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса AddComponentView
                        shouldExit = true;
                        break;

                    case 2:
                        _viewController.ChangeState(new DeleteComponentView(_viewController));
                        _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса DeleteComponentView
                        shouldExit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                        Console.ReadKey();
                        _viewController.ShowCurrentView();
                        shouldExit = true;
                        break;
                }
            }
        }
    }
}
