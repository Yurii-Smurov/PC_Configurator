using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Controllers;
using Configurator.Views.Renderers;
using Configurator.Views;

class Program
{
    static void Main()
    {
        // Тестирование работы билдера

        /*var pc = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .Build();

        pc.PrintComponents();*/

        // Тестирование миграции и заполнения базы данных через код

        /*using (var context = new PCComponentDbContext())
        {
            var processor = new Processor("intol", 2000, "sintol", 2000, 300000);
            context.Processors.Add(processor);
            context.SaveChanges();
        }*/

        MainMenuRenderer mainMenuRenderer = new MainMenuRenderer();
        MainMenuView mainMenuView = new MainMenuView(mainMenuRenderer);
        MenuController menuController = new MenuController(mainMenuView);

        menuController.StartMenu();
    }
}