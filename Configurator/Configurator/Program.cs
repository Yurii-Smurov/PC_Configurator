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

class Program
{
    static void Main()
    {
        // Тестирование работы ПК билдера

        var pcSborka = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .AddComponent(new GraphicsCard("intal", 2000, "sintol", 2000))
            .RemoveComponent(ComponentType.Processor)

            .Build();


        // Тестирование страницы регистрации
        /*var regView = new RegistrationView();
        regView.Show();*/

        // Тестирование страницы аутентификации
        var authView = new AuthView();
        authView.Show();

        // Присваивание переменной user данных о текущем пользователе
        var user = UserSession.GetInstance().CurrentUser;
        Console.WriteLine(user.Username);

        // Инициализируем репозиторий для работы с БД пользователей и их сборок компьютеров
        var userRepository = new SQLUserRepository(new UserDbContext());

        // Метод добавления готовой сборки ПК к учётной записи
        userRepository.AddPC(pcSborka, user);

        // Инициализируем утилиту, с помощтю которой будут выводиться данные о готовой сборке ПК/статусе сборки ПК на данный момент
        ConsolePCPrinter consolePCPrinter = new ConsolePCPrinter();

        // Тестирование получения данных из БД пользователей(UserName получаем из таблицы уч.записей,
        // PCId - из таблицы ПК, закреплённых за пользователем, Components - из таблицы комплектующих,
        // закреплённых за сборкой ПК)
        foreach (var pc in user.PCs)
        {
            Console.WriteLine($"Сборка пользователя {user.Username}: {pc.PCId}");
            consolePCPrinter.PrintComponents(pc.Components);
            Console.WriteLine();
        }

        // Тестирование метода удаления сборки ПК из БД (4 - ID сборки в БД, user - текующая сессия пользователя)
        //userRepository.DeletePC(4, user);

        // Тестирование миграции и заполнения базы данных комплектующих через код

        /*var processorRepository = new SQLComponentRepository<Processor>(new PCComponentDbContext());
        processorRepository.Add(new Processor("intol", 2000, "sintol", 2000, 300000));

        var gpuRepository = new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext());
        gpuRepository.Add(new GraphicsCard("intol", 2000, "sintol", 2000));*/

        // Тестирование вывода данных о комплектующих заданного типа в БД

        /*var componentListView = new ComponentListConsoleView<Processor>();
        componentListView.ShowList();*/
    }
}