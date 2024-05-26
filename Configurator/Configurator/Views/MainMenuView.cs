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
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Главная страница.");
                    Console.WriteLine($"Текущий пользователь: {UserSession.GetInstance().CurrentUser.Username}.");

                    Console.WriteLine("0. Выйти из приложения.");
                    Console.WriteLine("1. Начать или продолжить сборку ПК.");
                    Console.WriteLine("2. Завершить сборку ПК.");
                    Console.WriteLine("3. Посмотреть готовые сборки текущего пользователя.");

                    int choice = ConsoleInput.ReadInteger("Выбор: ");

                    switch (choice)
                    {
                        case 0:
                            Environment.Exit(0);
                            return;
                        case 1:
                            _viewController.ChangeState(new ChoosingComponentTypeView(_viewController));
                            _viewController.ShowCurrentView();
                            return;
                        case 2:
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
                                Console.Clear();
                                Console.WriteLine("Сборка ПК не завершена.");
                                Console.WriteLine("Не хватает одного из обязательных компонентов.");
                                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                            }
                            Console.ReadKey();
                            _viewController.ShowCurrentView();
                            return;
                        case 3:
                            Console.Clear();
                            foreach (var pc in UserSession.GetInstance().CurrentUser.PCs) // вывод информации о сборках текущего пользователя
                            {
                                Console.WriteLine($"Сборка пользователя {UserSession.GetInstance().CurrentUser.Username}: {pc.PCId}.");
                                ConsolePCPrinter.PrintComponents(pc.Components);
                                Console.WriteLine();
                            }
                            Console.WriteLine("Нажмите любую клавишу для продолжения.");
                            Console.ReadKey();
                            _viewController.ShowCurrentView();
                            return;
                        default:
                            Console.WriteLine("Некорректный выбор. Нажмите любую клавишу для повтора.");
                            Console.ReadKey();
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
        }
    }
}
