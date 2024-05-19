using Configurator.Models.UserModels;
using Configurator.Models.PCBuider;
using Configurator.Models.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Utils;
using Configurator.Views.UserInput;
using Configurator.Repositories.Interface;

namespace Configurator.Views
{
    class MainMenuView : IView
    {
        private readonly IUserRepository _userRepository;
        private readonly ViewController _viewController;

        public MainMenuView(IUserRepository userRepository, ViewController viewController)
        {
            _userRepository = userRepository;
            _viewController = viewController;
        }

        public void Show()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
            Console.Clear();
            Console.WriteLine("Главная страница");
            Console.WriteLine($"Текущий пользователь: {UserSession.GetInstance().CurrentUser.Username}");

            Console.WriteLine("0. Выйти из приложения");
            Console.WriteLine("1. Начать сборку ПК");
            Console.WriteLine("2. Завершить сборку ПК");
            Console.WriteLine("3. Посмотреть готовые сборки текущего пользователя");

            int choice = ConsoleInput.ReadInteger("Выбор: ");

            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    shouldExit = true;
                    _viewController.ChangeState(new ChoosingComponentTypeView(_viewController));
                    _viewController.ShowCurrentView();
                    break;
                case 2:
                    shouldExit = true;
                    var buildedPc = UserSession.GetInstance().PcBuilder.Build();
                    if (buildedPc != null)
                    {
                        _userRepository.AddPC(buildedPc, UserSession.GetInstance().CurrentUser);
                        UserSession.GetInstance().PcBuilder = new PCBuilder();
                        Console.WriteLine("Сборка ПК завершена.");
                        Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    }
                    else
                    {
                        Console.WriteLine("Сборка ПК не завершена.");
                        Console.WriteLine("Не хватает одного из обязательных компонентов.");
                        Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    }
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    break;
                case 3:
                    shouldExit = true;
                    Console.Clear();
                    foreach (var pc in UserSession.GetInstance().CurrentUser.PCs) // вывод информации о сборках текущего пользователя
                    {
                        Console.WriteLine($"Сборка пользователя {UserSession.GetInstance().CurrentUser.Username}: {pc.PCId}");
                        ConsolePCPrinter.PrintComponents(pc.Components);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    break;
                default:
                    shouldExit = true;
                    Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    break;
                }
            }
        }
    }
}
