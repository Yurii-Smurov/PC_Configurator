using Configurator.Models.Components;

namespace Configurator.Views.Utils
{
    static class ConsolePCPrinter
    {
        public static void PrintComponents(ICollection<PCComponent> components)
        {
            foreach (var component in components)
            {
                Console.WriteLine($"ID: {component.Id}, Комплектующее: {component.Type}, Название: {component.Name}, Стоимость: {component.Price}, Производитель: {component.Manufacturer}, Наличие в магазине: {component.Stock}");
            }
        }
    }
}
