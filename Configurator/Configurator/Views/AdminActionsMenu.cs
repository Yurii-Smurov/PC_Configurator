using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Admin;
using Configurator.Views.Director;
using Configurator.Views.UserInput;

namespace Configurator.Views
{
    class AdminActionsMenu : IView
    {
        private readonly ViewController _viewController;

        public AdminActionsMenu(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            try
            { 
            Console.Clear();
            Console.WriteLine("0. Выйти из приложения.");
            Console.WriteLine("1. Продолжить как пользователь.");
            Console.WriteLine("2. Продолжить как администратор.");

            int choice = ConsoleInput.ReadInteger("Выбор: ");
                while (true)
                {
                    switch (choice)
                    {
                        case 0:
                            Environment.Exit(0);
                            return;
                        case 1:
                            _viewController.ChangeState(new MainMenuView(new SQLUserRepository(new UserDbContext()), _viewController));
                            _viewController.ShowCurrentView();
                            return;
                        case 2:
                            if (UserSession.GetInstance().CurrentUser.UserRole == Role.Admin)
                            {
                                _viewController.ChangeState(new AdminMenuView(_viewController));
                                _viewController.ShowCurrentView();
                            }
                            else if (UserSession.GetInstance().CurrentUser.UserRole == Role.Director)
                            {
                                _viewController.ChangeState(new DirectorMenuView(_viewController));
                                _viewController.ShowCurrentView();
                            }
                            else if (UserSession.GetInstance().CurrentUser.UserRole == Role.User)
                            {
                                _viewController.ChangeState(new MainMenuView(new SQLUserRepository(new UserDbContext()), _viewController));
                                _viewController.ShowCurrentView();
                            }
                            else
                            {
                                _viewController.ChangeState(new EnterView(_viewController));
                                _viewController.ShowCurrentView();
                            }
                            return;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            Console.WriteLine("Для продолжения нажмите любую клавишу.");
                            Console.ReadKey();
                            _viewController.ShowCurrentView();
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
