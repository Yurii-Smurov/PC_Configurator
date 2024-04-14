using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Controllers;
using Configurator.Views.Renderers;
using Configurator.Views;
using Configurator.Repositories;

class Program
{
    static void Main()
    {
        // Тестирование работы билдера

        /*var pc = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .AddComponent(new GraphicsCard("intal", 2000, "sintol", 2000))

            .Build();

        ConsolePCPrinter consolePCPrinter = new ConsolePCPrinter();
        consolePCPrinter.PrintComponents(pc.Components);*/

        // Тестирование миграции и заполнения базы данных через код

        /*var processorRepository = new SQLComponentRepository<Processor>(new PCComponentDbContext());
        processorRepository.Add(new Processor("intol", 2000, "sintol", 2000, 300000));

        var processorsList = processorRepository.GetAll();
        foreach (var processor in processorsList)
        {
            Console.WriteLine(processor.Name);
        }

        var gpuRepository = new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext());
        gpuRepository.Add(new GraphicsCard("intol", 2000, "sintol", 2000));

        using (var context = new PCComponentDbContext())
        {
            var processor = new Processor("intol", 2000, "sintol", 2000, 300000);
            context.Processors.Add(processor);
            context.SaveChanges();
        }*/

        var componentListView = new ComponentListConsoleView<Processor>();
        componentListView.ShowList();

        /*MainMenuRenderer mainMenuRenderer = new MainMenuRenderer();
        MainMenuConsoleView mainMenuView = new MainMenuConsoleView(mainMenuRenderer);
        ConsoleMenuController menuController = new ConsoleMenuController(mainMenuView);

        menuController.StartMenu();*/
    }
}