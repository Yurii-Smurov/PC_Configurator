using Configurator.Authentication;
using Configurator.Repositories.MSSQL;
using Configurator.Services.RegistrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Auth
{
    class AuthView
    {
        public void Show()
        {
            Console.Write("Введите логин: ");
            string? login = Console.ReadLine();

            Console.Clear();

            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            Console.Clear();

            var authService = new AuthenticationService(new SQLUserRepository(new UserDbContext()));

            if (authService.AuthenticateUser(login, password) is null) 
            {
                Console.WriteLine("Неправильный логин или пароль.");
            }
            else
            {
                Console.WriteLine("Вход выполнен успешно");
            }
        }
    }
}
