using Configurator.Authentication;
using Configurator.Services.RegistrationService;
using Configurator.Repositories.MSSQL;
using Configurator.Repositories.Interface;
using Configurator.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Configurator.Views.Auth
{
    class RegistrationView : IView
    {
        private ViewController _viewController;
        private IUserRepository _userRepository;
        
        public RegistrationView(ViewController viewController)
        {
            _viewController = viewController;
            _userRepository = new SQLUserRepository(new UserDbContext());
        }

        public void Show()
        {
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Пароль должен содержать:");
            Console.WriteLine("Только символы латиницы");
            Console.WriteLine("От 6 до 12 символов");
            Console.WriteLine("Как минимум один символ верхнего регистра");
            Console.WriteLine("Как минимум одно число");
            Console.WriteLine("Как минимум один специальный символ(!@#$%^&*()_+=\\[{\\]};:<>|./?-)");
            Console.WriteLine();
            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();
            Console.Write("Введите пароль(второй раз): ");
            string? repeatedPassword = Console.ReadLine();

            Console.Clear();

            Console.Write("Введите свою почту: ");
            string? email = Console.ReadLine();

            var regService = new RegistrationService(_userRepository);
            if (!regService.RegisterUser(login, password, repeatedPassword, email))
            {
                int choice;

                bool shouldExit = false;

                while (!shouldExit)
                {
                    Console.WriteLine("Аккаунт не зарегистрирован:");
                    Console.WriteLine("Один из пунктов не соответствует заданным требованиям");
                    Console.WriteLine("Также возможно, что аккаунт с таким именем пользователя уже существует");
                    Console.WriteLine();
                    Console.WriteLine("Повторить попытку регистрации?");
                    Console.WriteLine("1 - да.");
                    Console.WriteLine("2 - нет.");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Неправильный ввод. Пожалуйста, введите целое число.");
                    }

                    switch (choice)
                    {
                        case 1:
                            shouldExit = true;
                            _viewController.ChangeState(new RegistrationView(_viewController));
                            _viewController.ShowCurrentView();
                            break;
                        case 2:
                            shouldExit = true;
                            _viewController.ChangeState(new EnterView(_viewController));
                            _viewController.ShowCurrentView();
                            break;
                        default:
                            shouldExit = true;
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Аккаунт зарегистрирован!");
                _viewController.ChangeState(new AuthView(_viewController));
                _viewController.ShowCurrentView();
            }
        }
    }
}
