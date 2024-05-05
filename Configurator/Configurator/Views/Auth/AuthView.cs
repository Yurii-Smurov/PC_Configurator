using Configurator.Authentication;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
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

            Console.Clear();

            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();

            Console.Clear();

            var authService = new AuthenticationService(new SQLUserRepository(new UserDbContext()));

            var user = authService.AuthenticateUser(login, password);

            if (user == null) 
            {
                Console.WriteLine("Неправильный логин или пароль.");
            }
            else
            {
                UserSession.GetInstance().CurrentUser = user;
                Console.WriteLine("Вход выполнен успешно");
                _viewController.ChangeState(new MainMenuView(_viewController));
                _viewController.ShowCurrentView();
            }
        }
    }
}
