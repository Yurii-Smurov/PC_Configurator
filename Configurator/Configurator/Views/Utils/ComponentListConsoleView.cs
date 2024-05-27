using Configurator.Models.Components;
using Configurator.Repositories;

namespace Configurator.Views.Utils
{
    static class ComponentListConsoleView<T>
        where T : PCComponent 
    {
        public static void ShowList(IComponentRepository<T> componentRepository)
        {
            try
            {
                var componentList = componentRepository.GetAll();

                foreach (var component in componentList)
                {
                    Console.WriteLine($"Id: {component.Id} Название: {component.Name} Производитель: {component.Manufacturer} Наличие: {component.Stock} Стоимость: {component.Price}");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine("Произошла ошибка:");
                Console.WriteLine(e.Message); // Вывод сообщения об ошибке
                Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу.");
                Console.ReadKey();
                return;
            }
        }
    }
}
