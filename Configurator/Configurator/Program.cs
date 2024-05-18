using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Models.UserModels;
using Configurator.Views.Utils;
using Configurator.Views;
using Configurator.Repositories;
using Configurator.Repositories.MSSQL;
using Configurator.Authentication;
using Configurator.Views.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

class Program
{
    static void Main()
    {
        // Тестирование работы ПК билдера

        var pcSborka = new PCBuilder()
                .AddComponent(new Processor("intel", 15000, "i5", 500, "lg1700", true, true, true, 117))
                .AddComponent(new GraphicsCard("nvidia", 150000, "rtx4090", 1500, "1", "gddr6", 2400, 512))
                .Build();

        /*ConsolePCPrinter consolePCPrinter = new ConsolePCPrinter();
        consolePCPrinter.PrintComponents(pc.Components);*/

        // Тестирование страницы регистрации
        ViewController stateController = new ViewController();
        stateController.ShowCurrentView(); // Отображается начальная страница авторизации.
        //// Присваивание переменной user данных о текущем пользователе
        //var user = UserSession.GetInstance().CurrentUser;

        // Инициализируем репозиторий для работы с БД пользователей и их сборок компьютеров
        //var userRepository = new SQLUserRepository(new UserDbContext());

        // Метод добавления готовой сборки ПК к учётной записи
        //userRepository.AddPC(pcSborka, UserSession.GetInstance().CurrentUser);

        // Инициализируем утилиту, с помощтю которой будут выводиться данные о готовой сборке ПК/статусе сборки ПК на данный момент
        //ConsolePCPrinter consolePCPrinter = new ConsolePCPrinter();

        //Тестирование получения данных из БД пользователей(UserName получаем из таблицы уч.записей,
        //PCId -из таблицы ПК, закреплённых за пользователем, Components -из таблицы комплектующих,
        //закреплённых за сборкой ПК)
        /*foreach (var pc in UserSession.GetInstance().CurrentUser.PCs)
        {
            Console.WriteLine($"Сборка пользователя {UserSession.GetInstance().CurrentUser.Username}: {pc.PCId}");
            consolePCPrinter.PrintComponents(pc.Components);
            Console.WriteLine();
        }*/

        // Тестирование метода удаления сборки ПК из БД (4 - ID сборки в БД, user - текующая сессия пользователя)
        //userRepository.DeletePC(4, user);

        // Тестирование миграции и заполнения базы данных комплектующих через код

       /* var processorRepository = new SQLComponentRepository<Processor>(new PCComponentDbContext());
        processorRepository.Add(new Processor("intel", 15000, "i5", 500, "lg1700", true, true, true, 117));

        var gpuRepository = new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext());
        gpuRepository.Add(new GraphicsCard("nvidia", 150000, "rtx4090", 1500, "1", "gddr6", 2400, 512));*/

        // Тестирование вывода данных о комплектующих заданного типа в БД

        /*var componentListView = new ComponentListConsoleView<Processor>();
        componentListView.ShowList();*/
    }
}