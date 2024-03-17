using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Components
{
    sealed class ProcessorCooler : PCComponent
    {
        // Конструктор затычка
        public ProcessorCooler(string name, decimal price, string manufacturer, int stock) : base(name, price, manufacturer, stock)
        {
        }
    }
}
