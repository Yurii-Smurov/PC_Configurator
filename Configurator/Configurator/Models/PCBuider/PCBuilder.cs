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
        public PC? Build()
        {
            if (IsValidConfiguration())
                return new PC(Components);
            else
                return null;
        }


        public bool HasComponentOfType(ComponentType type)
        {
            return Components.Any(c => c.Type == type);
        }

        private bool IsValidConfiguration()
        {
            bool hasProcessor = HasComponentOfType(ComponentType.Processor);
            bool hasGraphicsCard = HasComponentOfType(ComponentType.GraphicsCard);
            bool hasMotherboard = HasComponentOfType(ComponentType.Motherboard);
            bool hasPowerUnit = HasComponentOfType(ComponentType.PowerUnit);
            bool hasComputerCase = HasComponentOfType(ComponentType.ComputerCase);
            bool hasMemory = HasComponentOfType(ComponentType.Memory);
            bool hasStorage = HasComponentOfType(ComponentType.HDD) || HasComponentOfType(ComponentType.SSD);
            bool hasCoolingSystem = HasComponentOfType(ComponentType.AirCoolingSystem) || HasComponentOfType(ComponentType.LiquidCoolingSystem);

            return hasProcessor && hasGraphicsCard && hasMotherboard && hasPowerUnit && hasComputerCase && hasMemory && hasStorage && hasCoolingSystem;
        }

    }
}