using Configurator.Authentication;
using Configurator.Services.RegistrationService;
using Configurator.Repositories.MSSQL;
using Configurator.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Auth
{
    class RegistrationView : IView
    {
        public void Next()
        {
            new AuthView().Show();
        }

        public void Previous()
        {
            new RegistrationView().Show();
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

            Console.Clear();

            var regService = new RegistrationService(new SQLUserRepository(new UserDbContext()));
            if (!regService.RegisterUser(login, password, repeatedPassword, email))
            {
                Console.WriteLine("Аккаунт не зарегистрирован:");
                Console.WriteLine("Один из пунктов не соответствует заданным требованиям");
                Console.WriteLine("Повторить повытку регистрации?");
                Console.WriteLine("1 - да.");
                Console.WriteLine("2 - нет.");

                int choice;
                
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Неправильный ввод. Пожалуйста, введите целое число.");
                }

                while (true)
                {
                    switch (choice)
                    {
                        case 1:
                            Previous();
                            break;
                        case 2:
                            Next();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Аккаунт зарегистрирован");
                Next();
            }
        }
    }
}
