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
        public IEnumerable<PCComponent> Components { get; set; }

        /// <summary>
        /// Конструктор ПК
        /// </summary>
        /// <param name="components"></param>
        public PC(IEnumerable<PCComponent> components)
        {
            Components = components;
        }
    }
}
