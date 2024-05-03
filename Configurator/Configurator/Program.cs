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
        // Тестирование работы билдера



        /*var pc = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .AddComponent(new GraphicsCard("intal", 2000, "sintol", 2000))
            .RemoveComponent(ComponentType.Processor)

            .Build();*/

        /*ConsolePCPrinter consolePCPrinter = new ConsolePCPrinter();
        consolePCPrinter.PrintComponents(pc.Components);*/

        UserSession.GetInstance().CurrentUser = null;


        /*var regView = new RegistrationView();
        regView.Show();*/

        var authView = new AuthView();
        authView.Show();
        //Console.Clear();
        var user =  UserSession.GetInstance().CurrentUser;
        Console.WriteLine(user.Username);

        //User user = new User("Нюхатель", "123456", "шило на мыло");
        //var userRepository = new SQLUserRepository(new UserDbContext());
        //userRepository.Add(user);
        //userRepository.Delete(userRepository.GetUserByUsername("Нюхатель"));

        // Тестирование миграции и заполнения базы данных комплектующих через код

        /*var processorRepository = new SQLComponentRepository<Processor>(new PCComponentDbContext());
        processorRepository.Add(new Processor("intol", 2000, "sintol", 2000, 300000));

        var gpuRepository = new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext());
        gpuRepository.Add(new GraphicsCard("intol", 2000, "sintol", 2000));

        var processorsList = processorRepository.GetAll();
        foreach (var processor in processorsList)
        {
            Console.WriteLine(processor.Name);
        }*/


        //var componentListView = new ComponentListConsoleView<Processor>();
        //componentListView.ShowList();

        /*MainMenuRenderer mainMenuRenderer = new MainMenuRenderer();
        MainMenuConsoleView mainMenuView = new MainMenuConsoleView(mainMenuRenderer);
        ConsoleMenuController menuController = new ConsoleMenuController(mainMenuView);

        menuController.StartMenu();*/
    }
}