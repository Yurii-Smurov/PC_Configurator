using Configurator.Views.Admin;
using Configurator.Views.Auth;
using Configurator.Views.Director;
using Configurator.Views.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class EnterView : IView
    {
        private readonly ViewController _viewController;

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
            Console.WriteLine("Введите номер действия и нажмите enter: ");

            int choice = ConsoleInput.ReadInteger("Выбор: ");

            switch (choice)
            {
                case 0:
                    Environment.Exit(0); 
                    return;
                case 1:
                    _viewController.ChangeState(new AuthView(_viewController));
                    _viewController.ShowCurrentView();
                    return;
                case 2:
                    _viewController.ChangeState(new RegistrationView(_viewController));
                    _viewController.ShowCurrentView();
                    return;
                default:
                    Console.WriteLine("Неверный выбор, нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    return;
                }
            }
        }
    }
}
