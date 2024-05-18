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
    class ConsolePCPrinter
    {
        public void PrintComponents(ICollection<PCComponent> components)
        {
            foreach (var component in components)
            {
                Console.WriteLine($"ID: {component.Id}, Component: {component.Name}, Price: {component.Price}, Manufacturer: {component.Manufacturer}, Stock: {component.Stock}");
            }
        }
    }
}
