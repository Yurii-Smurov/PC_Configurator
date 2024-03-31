using Configurator;
using Configurator.Controllers;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Views;

class Program
{
    static void Main()
    {
        /*var pc = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .Build();

        pc.PrintComponents();*/

        //тестирование заполнения База данных через код

        /*using (var context = new PCComponentDbContext())
        {
            var processor = new Processor("intol", 2000, "sintol", 2000, 300000);
            context.Processors.Add(processor);
            context.SaveChanges();
        }*/

        MainMenuView view = new MainMenuView();
        MenuController controller = new MenuController(view);

        controller.StartMenu();
    }
}