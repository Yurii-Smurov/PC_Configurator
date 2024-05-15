using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public GraphicsCard(string name, decimal price, string manufacturer, int stock, string modelGPU, string typeMEM, int freq, int volume) : base(name, price, manufacturer, stock)
        {
            ModelGPU = modelGPU;
            TypeMEM = typeMEM;
            Freq = freq;
            Volume = volume;

            Type = ComponentType.GraphicsCard;
        }

        public string ModelGPU { get; set; }
        public string TypeMEM { get; set; }
        public int Freq { get; set; }
        public int Volume { get; set; }

    }
}
