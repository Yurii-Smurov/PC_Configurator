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

        private readonly ViewController _viewController;

        public AdminMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            try
            {
                bool shouldExit = false;
                while (!shouldExit)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("0. Выйти из приложения");
                    Console.WriteLine("1. Добавить комплектующее");
                    Console.WriteLine("2. Удалить комплектующее");

                    int choice = ConsoleInput.ReadInteger("Выбор: "); // вызов метода GetChoice и сохранение введенного пользователем значения

                    switch (choice)
                    {
                        case 0:
                            Environment.Exit(0);
                            return;
                        case 1:
                            _viewController.ChangeState(new AddComponentView(_viewController)); // создание экземпляра класса AddComponentView
                            _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса AddComponentView
                            return;

                        case 2:
                            _viewController.ChangeState(new DeleteComponentView(_viewController));
                            _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса DeleteComponentView
                            return;

                        default:
                            Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                            Console.ReadKey();
                            _viewController.ShowCurrentView();
                            return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Произошла ошибка:");
                Console.WriteLine(e.Message); // Вывод сообщения об ошибке
                Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу.");
                Console.ReadKey();
                _viewController.ShowCurrentView();
                return;
            }
        }
    }
}
