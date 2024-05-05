using Configurator.Models.Components;
using Configurator.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.PCBuider
{
    class PC
    {
        // Свойство - список подобранных комплектующих ПК
        public ICollection<PCComponent> Components { get; set; }
        public User User { get; set; } = null!;
        public int PCId { get; set; }

        /// <summary>
        /// Конструктор ПК
        /// </summary>
        /// <param name="components"></param>
        public PC(ICollection<PCComponent> components)
        {
            Components = components;
        }

        public PC()
        {
        }
    }
}
