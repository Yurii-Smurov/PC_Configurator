using Configurator.Models.Components;
using Configurator.Models.UserModels;
using Configurator.Repositories;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Director;
using Configurator.Views.UserInput;
using Configurator.Views.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Admin
{
    class DeleteComponentView : IView
    {
        private readonly ViewController _viewController;

        public DeleteComponentView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            try
            {
                bool shouldExit = false;

                while (!shouldExit)
                {
                    Console.WriteLine("Удалить комплектующее");
                    Console.Clear();
                    Console.WriteLine("0 Вернуться");
                    Console.WriteLine("1 Процессор");
                    Console.WriteLine("2 Материнская плата");
                    Console.WriteLine("3 Видеокарта");
                    Console.WriteLine("4 Оперативная память");
                    Console.WriteLine("5 Корпус");
                    Console.WriteLine("6 Блок Питания");
                    Console.WriteLine("7 HDD");
                    Console.WriteLine("8 SSD");
                    Console.WriteLine("9 Система воздушного охлаждения процессора");
                    Console.WriteLine("10 Система водяного охлаждения процессора");
                    Console.WriteLine("11 Звуковая карта");

                    int choice = ConsoleInput.ReadInteger("Выбор: ");

                    switch (choice)
                    {
                        case 0:
                            if (UserSession.GetInstance().CurrentUser.UserRole == Role.Admin)
                            {
                                _viewController.ChangeState(new AdminMenuView(_viewController));
                            }
                            else if (UserSession.GetInstance().CurrentUser.UserRole == Role.Director)
                            {
                                _viewController.ChangeState(new DirectorMenuView(_viewController));
                            }
                            else
                            {
                                _viewController.ChangeState(new EnterView(_viewController));
                            }

                            _viewController.ShowCurrentView();
                            return;
                        case 1:
                            DeleteComponent(new SQLComponentRepository<Processor>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 2:
                            DeleteComponent(new SQLComponentRepository<Motherboard>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 3:
                            DeleteComponent(new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 4:
                            DeleteComponent(new SQLComponentRepository<Memory>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 5:
                            DeleteComponent(new SQLComponentRepository<ComputerCase>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 6:
                            DeleteComponent(new SQLComponentRepository<PowerUnit>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 7:
                            DeleteComponent(new SQLComponentRepository<HDD>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 8:
                            DeleteComponent(new SQLComponentRepository<SSD>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 9:
                            DeleteComponent(new SQLComponentRepository<AirCoolingSystem>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 10:
                            DeleteComponent(new SQLComponentRepository<LiquidCoolingSystem>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;
                        case 11:
                            DeleteComponent(new SQLComponentRepository<SoundCard>(new PCComponentDbContext()));
                            shouldExit = true;
                            break;

                        default:
                            Console.WriteLine("Неверный выбор, нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            shouldExit = true;
                            break;
                    }
                    _viewController.ShowCurrentView();
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

        private static void DeleteComponent<T>(IComponentRepository<T> componentRepository) where T : PCComponent
        {
            {
                Console.WriteLine("Список комплектующих заданного типа.");
                ComponentListConsoleView<T>.ShowList(componentRepository);
                int id = ConsoleInput.ReadInteger("Введите id комплектующего для удаления или введите 0 для отмены действия: ");
                if (id != 0)
                {
                    T? component = componentRepository.GetComponent(id);

                    if (component != null)
                    {
                        componentRepository.Delete(component);
                        Console.WriteLine("Комплектующее успешно удалено.");
                    }
                    else
                    {
                        Console.WriteLine("Комплектующее с указанным id не найдено.");
                    }
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
            }
        }
    }
}
