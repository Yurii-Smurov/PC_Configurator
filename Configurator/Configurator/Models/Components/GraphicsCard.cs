using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class GraphicsCard : PCComponent
    {
        public GraphicsCard()
        {
            Type = ComponentType.GraphicsCard;
        }

        public GraphicsCard(string name, decimal price, string manufacturer, int stock) : base(name, price, manufacturer, stock)
        {
            Type = ComponentType.GraphicsCard;
        }

        public string ModelGPU { get; set; }
        public string TypeMEM { get; set; }
        public int Freq { get; set; }
        public int Volume { get; set; }

    }
}
