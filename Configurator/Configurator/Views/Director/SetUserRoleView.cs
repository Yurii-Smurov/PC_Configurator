using Configurator.Models.UserModels;
using Configurator.Repositories.Interface;
using Configurator.Repositories.MSSQL;
using Configurator.Views.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Director
{
    class SetUserRoleView : IView
    {
        private readonly ViewController _viewController;
        private readonly IUserRepository _userRepository;

        public SetUserRoleView(ViewController viewController, IUserRepository userRepository)
        {
            _viewController = viewController;
            _userRepository = userRepository;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Назначить роль пользователя.");

            string userName = ConsoleInput.ReadString("Имя пользователя (для выхода введите '0'): ");

            if (userName == "0")
            {
                _viewController.ChangeState(new DirectorMenuView(_viewController));
                _viewController.ShowCurrentView();
                return;
            }

            User? foundedUser = null;
            try
            {
                // Найти пользователя с указанным именем пользователя
                foundedUser = _userRepository.GetUserByUsername(userName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при поиске данных о пользователе: {e.Message}");
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
                Console.ReadKey();
                _viewController.ChangeState(this);
                _viewController.ShowCurrentView();
                return;
            }

            if (foundedUser == null)
            {
                Console.WriteLine("Пользователь с таким именем не найден.");
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
                Console.ReadKey();
                _viewController.ChangeState(this);
                _viewController.ShowCurrentView();
                return;
            }

            if (foundedUser.UserRole == Role.Director)
            {
                Console.WriteLine("Роль Директора можно изменить только в базе данных.");
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
                Console.ReadKey();
                _viewController.ChangeState(this);
                _viewController.ShowCurrentView();
                return;
            }

            // Запросить и проверить выбор роли пользователя
            bool isChoiceValid = false;
            while (!isChoiceValid)
            {
                Console.WriteLine("Выберите роль для пользователя:");
                Console.WriteLine("1 - Обычный пользователь");
                Console.WriteLine("2 - Администратор");

                int choice;
                choice = ConsoleInput.ReadInteger("Выбор: ");

                switch (choice)
                {
                    case 1:
                        isChoiceValid = true;
                        foundedUser.UserRole = Role.User;
                        break;
                    case 2:
                        isChoiceValid = true;
                        foundedUser.UserRole = Role.Admin;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }

            // Обновить пользователя и вывести сообщение об успехе
            try
            {
                _userRepository.UpdateUser(foundedUser);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при обновлении пользовательских данных: {e.Message}");
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
                Console.ReadKey();
                _viewController.ChangeState(this);
                _viewController.ShowCurrentView();
                return;
            }

            Console.WriteLine($"Пользователю {userName} назначена роль {foundedUser.UserRole}");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
            Console.ReadKey();

            // Вернуться на страницу действий директора
            _viewController.ChangeState(new DirectorMenuView(_viewController));
            _viewController.ShowCurrentView();
        }
    }
}
