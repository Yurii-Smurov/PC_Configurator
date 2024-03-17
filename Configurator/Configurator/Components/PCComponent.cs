using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Components
{
    enum ComponentType
    {
        Processor,
        ProcessorCooler,
        Motherboard,
        GraphicsCard,
        PowerUnit,
        Drive,
        ComputerCase,
        RAM,
        SoundCard
    }
    /// <summary>
    /// Шаблон для комплектующих
    /// </summary>
    abstract class PCComponent
    {
        // Базовый конструктор для всех компонентов
        protected PCComponent(string name, decimal price, string manufacturer, int stock)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            Stock = stock;
        }
        // Базовые свойства для всех компонентов
        public string Name { get; } = string.Empty;
        public decimal Price { get; } = 0m;
        public int Stock { get; } = 0;
        public string Manufacturer { get; } = string.Empty;
        public ComponentType Type { get; protected set; }
    }
}
