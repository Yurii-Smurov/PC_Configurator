using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;

namespace Configurator.Views.Utils
{
    static class ConsolePCPrinter
    {
        public static void PrintComponents(ICollection<PCComponent> components)
        {
            foreach (var component in components)
            {
                Console.WriteLine($"ID: {component.Id}, Комплектующее: {component.Name}, Стоимость: {component.Price}, Производитель: {component.Manufacturer}, Наличие в магазине: {component.Stock}");
            }
        }
    }
}
