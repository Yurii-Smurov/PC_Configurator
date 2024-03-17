using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Components;

namespace Configurator.PCBuider
{

    class PCBuilder
    {
        private List<PCComponent> _components = new List<PCComponent>();
        public PCBuilder AddComponent(PCComponent component)
        {
            if (HasComponentOfType(component.Type))
            {
                Console.WriteLine($"Компонент типа {component.Type} уже присутствует в сборке.");
            }
            else
            {
                _components.Add(component);
            }
            return this;
        }

        public PC Build()
        {
            // Дополнительная логика проверки и создания объекта PC
            return new PC(_components);
        }

        public bool HasComponentOfType(ComponentType type)
        {
            return _components.Any(c => c.Type == type);
        }

    }
}