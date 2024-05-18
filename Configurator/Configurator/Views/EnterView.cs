using Configurator.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class EnterView : IView
    {
        private ViewController _viewController;

        public EnterView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
            Console.Clear();
            Console.WriteLine("0. Выйти из приложения");
            Console.WriteLine("1. Войти в аккаунт");
            Console.WriteLine("2. Регистрация аккаунта");
            Console.WriteLine();
            Console.Write("Введите номер действия и нажмите enter: ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                shouldExit = true;
                Console.WriteLine("Неправильный ввод. Пожалуйста, введите целое число.");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                _viewController.ShowCurrentView();
            }

            switch (choice)
            {
                case 0:
                    Environment.Exit(0); 
                    break;
                case 1:
                    shouldExit = true;
                    _viewController.ChangeState(new AuthView(_viewController));
                    _viewController.ShowCurrentView();
                    break;
                case 2:
                    shouldExit = true;
                    _viewController.ChangeState(new RegistrationView(_viewController));
                    _viewController.ShowCurrentView();
                    break;
                default:
                    shouldExit = true;
                    Console.WriteLine("Неверный выбор, нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    break;
                }
            }
        }
    }
}
