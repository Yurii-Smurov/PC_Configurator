using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.Components;

namespace Configurator.Models.PCBuider
{
    /// <summary>
    /// Класс, содержащий методы для изменения компонентов ПК
    /// </summary>
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

        /// <summary>
        /// Метод, возвращающий объект класса PC из подобранных компонентов
        /// </summary>
        /// <returns></returns>
        public PC Build()
        {
            // Здесь необходимо реализовать логику проверки(Проверить наличие обязательных компонентов) и создания объекта PC
            return new PC(_components);
        }

        public bool HasComponentOfType(ComponentType type)
        {
            return _components.Any(c => c.Type == type);
        }

    }
}