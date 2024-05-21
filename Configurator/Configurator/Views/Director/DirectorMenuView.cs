using Configurator.Views.Admin;
using Configurator.Views.UserInput;
using Configurator.Repositories.MSSQL;
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
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("0. Выйти из приложения");
                    Console.WriteLine("1. Добавить комплектующее");
                    Console.WriteLine("2. Удалить комплектующее");
                    Console.WriteLine("3. Назначить роль пользователя");

                    int choice = ConsoleInput.ReadInteger("Выбор: ");

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

                        case 3:
                            _viewController.ChangeState(new SetUserRoleView(_viewController, new SQLUserRepository(new UserDbContext())));
                            _viewController.ShowCurrentView(); // вызов метода Show у экземпляра класса DeleteComponentView
                            return;

                        default:
                            Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                            Console.ReadKey();
                            return;
                    }
                }
            }
            catch(Exception e) 
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
