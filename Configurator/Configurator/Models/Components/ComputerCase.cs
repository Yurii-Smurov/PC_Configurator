using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class ComputerCase : PCComponent
    {
        public ComputerCase()
        {
            Type = ComponentType.ComputerCase;
        }

        public ComputerCase(string name, decimal price, string manufacturer, int stock) : base(name, price, manufacturer, stock)
        {
            Type = ComponentType.ComputerCase;
        }

        // Конструктор затычка

        public string Form { get; set; }
    }
}
