using Configurator.Authentication;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Admin;
using Configurator.Views.Director;
using Configurator.Services.RegistrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Auth
{
    class AuthView : IView
    {
        private ViewController _viewController;

        public AuthView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            Console.Clear();

            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string? password = ReadPassword();

            Console.Clear();

            var authService = new AuthenticationService(new SQLUserRepository(new UserDbContext()));

            var user = authService.AuthenticateUser(login, password);

            if (user == null) 
            {
                Console.WriteLine("Вход не выполнен, введён неправильный логин или пароль.");
                Console.WriteLine("нажмите любую клавишу для продолжения");
                Console.ReadKey();
                _viewController.ChangeState(new EnterView(_viewController));
                _viewController.ShowCurrentView();
            }
            else
            {
                UserSession.GetInstance().CurrentUser = user;
                Console.WriteLine("Вход выполнен успешно, нажмите любую клавишу для продолжения");
                Console.ReadKey();
                switch (UserSession.GetInstance().CurrentUser.UserRole)
                {
                    case Role.User:
                        _viewController.ChangeState(new MainMenuView(_viewController));
                        break;
                    case Role.Admin:
                        _viewController.ChangeState(new AdminMenuView(_viewController));
                        break;
                    case Role.Director:
                        _viewController.ChangeState(new DirectorMenuView(_viewController));
                        break;
                    default:
                        UserSession.GetInstance().CurrentUser = null;
                        _viewController.ChangeState(new EnterView(_viewController));
                        break;
                }
                _viewController.ShowCurrentView();
            }
        }

        private static string ReadPassword()
        {
            StringBuilder passwordBuilder = new StringBuilder();
            while (true)
            {
                // Читать следующий символ
                var key = Console.ReadKey(true);

                // Если пользователь нажал Enter, завершить ввод
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                // Если Backspace, удалить последний символ в строке
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (passwordBuilder.Length > 0)
                    {
                        passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                // Иначе добавить символ в строку и отобразить *
                else
                {
                    passwordBuilder.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            return passwordBuilder.ToString();
        }
    }
}
