﻿using Configurator.Authentication;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using System.Text;
using Configurator.Views.UserInput;

namespace Configurator.Views.Auth
{
    class AuthView : IView
    {
        private readonly ViewController _viewController;

        public AuthView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            try
            {
                Console.Clear();

                string? login = ConsoleInput.ReadString("Введите логин:");

                Console.WriteLine("Введите пароль: ");
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
                            _viewController.ChangeState(new MainMenuView(new SQLUserRepository(new UserDbContext()), _viewController));
                            break;
                        case Role.Admin:
                            _viewController.ChangeState(new AdminActionsMenu(_viewController));
                            break;
                        case Role.Director:
                            _viewController.ChangeState(new AdminActionsMenu(_viewController));
                            break;
                        default:
                            _viewController.ChangeState(new EnterView(_viewController));
                            break;
                    }
                    _viewController.ShowCurrentView();
                    return;
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
