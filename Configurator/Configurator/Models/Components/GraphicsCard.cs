using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class GraphicsCard : PCComponent
    {
        // Конструктор затычка
        public GraphicsCard(string name, decimal price, string manufacturer, int stock) : base(name, price, manufacturer, stock)
        {
        }
    }
}
