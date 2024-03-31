using Configurator.Models.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.PCBuider
{
    class PC
    {
        // Свойство - список подобранных комплектующих ПК
        public List<PCComponent> Components { get; }
        //конструктор ПК
        public PC(List<PCComponent> components)
        {
            Components = components;
        }

        /// <summary>
        /// Вывод данных о подобранных комплектующих
        /// </summary>
        public void PrintComponents()
        {
            foreach (var component in Components)
            {
                Console.WriteLine($"Component: {component.Name}, Price: {component.Price}, Manufacturer: {component.Manufacturer}, Stock: {component.Stock}");

                if (component is Processor processor)
                {
                    Console.WriteLine($"Frequency: {processor.Frequency}");
                }
            }

        }
    }
}
