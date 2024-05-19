using Configurator.Models.Components;
using Configurator.Models.UserModels;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Utils;
using Configurator.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Configurator.Repositories;
using Configurator.Views.UserInput;

namespace Configurator.Views
{
    class ChooseComponentView<T> : IView
        where T : PCComponent
    {
        private readonly ConsolePCPrinter _pcPrinter = new ConsolePCPrinter();
        private readonly IComponentRepository<T> _componentRepository;
        private readonly int pageSize = 10; // Количество элементов на странице
        private IEnumerable<PCComponent>? _componentList;

        public ChooseComponentView(IComponentRepository<T> componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public void Show()
        {
            int pageNumber = 0; // Номер текущей страницы
            bool exit = false;

            _componentList = _componentRepository.GetAll();

            while (!exit)
            {
                IEnumerable<PCComponent> itemsToShow = _componentList.Skip(pageNumber * pageSize).Take(pageSize).ToList();

                Console.Clear();
                Console.WriteLine($"Страница {pageNumber + 1}");
                foreach (var item in itemsToShow)
                {
                    Console.WriteLine($"{item.Id} {item.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Команды:");
                Console.WriteLine("[>] - следующая страница");
                Console.WriteLine("[<] - предыдущая страница");
                Console.WriteLine("[Esc] - выход");
                Console.WriteLine("[Enter] - выбрать комплектующее");

                var command = Console.ReadKey().Key;

                switch (command)
                {
                    case ConsoleKey.RightArrow:
                        if(itemsToShow.Any()) pageNumber++;
                        break;
                    case ConsoleKey.LeftArrow:
                        pageNumber = (pageNumber > 0) ? pageNumber - 1 : 0;
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.Enter:
                        ChooseComponent();
                        Console.Clear();
                        _pcPrinter.PrintComponents(UserSession.GetInstance().PcBuilder.Components);
                        Console.ReadKey();
                        exit = true;
                        break;
                }
            }
        }

        private void ChooseComponent()
        {
            int choiceId = ConsoleInput.ReadInteger("Введите ID комплектующего");

            var foundedComponent = _componentList.FirstOrDefault(c => c.Id == choiceId);
            if (foundedComponent != null)
            {
                if (UserSession.GetInstance().PcBuilder.HasComponentOfType(foundedComponent.Type))
                {
                    Console.WriteLine("В текущей сборке присутствует компонент этого типа.");
                    Console.WriteLine("Желаете ли вы поменять комплектующее в текущей сборке?");
                    Console.WriteLine("1 - Да.");
                    Console.WriteLine("2 - Нет.");

                    int choice = ConsoleInput.ReadInteger("Введите вариант:");

                    switch (choice)
                    {
                        case 1:
                            UserSession.GetInstance().PcBuilder.RemoveComponent(foundedComponent.Type);
                            UserSession.GetInstance().PcBuilder.AddComponent(foundedComponent);
                            Console.WriteLine("Комплектующее изменено!");
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }    
                }
                else
                {
                    UserSession.GetInstance().PcBuilder.AddComponent(foundedComponent);
                    Console.WriteLine("Компонент добавлен!");
                }
            }
            else
            {
                Console.WriteLine("Компонент с таким ID не найден.");
            }
        }
    }
}
