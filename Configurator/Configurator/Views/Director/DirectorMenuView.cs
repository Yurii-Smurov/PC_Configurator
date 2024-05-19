using Configurator.Views.Admin;
using Configurator.Views.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Director
{
    class DirectorMenuView : IView
    {
        private readonly ViewController _viewController;

        public DirectorMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие директора:");
                Console.WriteLine("1. Добавить комплектующее");
                Console.WriteLine("2. Удалить комплектующее");
                Console.WriteLine("3. Назначить роль пользователя");

                int choice = ConsoleInput.ReadInteger("Выбор: ");

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

                    case 3:
                        _viewController.ChangeState(new SetUserRoleView(_viewController));
                        _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса DeleteComponentView
                        shouldExit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                        Console.ReadKey();
                        shouldExit = true;
                        break;
                }
            }
        }
    }
}
