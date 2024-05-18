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
        public ICollection<PCComponent> Components = new List<PCComponent>();
        public PCBuilder AddComponent(PCComponent component)
        {
            //if (!HasComponentOfType(component.Type))
            {
                Components.Add(component);
            }
            return this;
        }

        public PCBuilder RemoveComponent(ComponentType componentType)
        {
            if (HasComponentOfType(componentType))
            {
                Components.Remove(Components.FirstOrDefault(c => c.Type == componentType));
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
            return new PC(Components);
        }

        public bool HasComponentOfType(ComponentType type)
        {
            return Components.Any(c => c.Type == type);
        }

    }
}