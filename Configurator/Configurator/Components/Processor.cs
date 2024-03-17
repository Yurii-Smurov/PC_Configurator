using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Components
{
    /// <summary>
    /// Класс процессора
    /// </summary>
    sealed class Processor : PCComponent
    {
        public Processor(string name, decimal price, string manufacturer, int stock, int frequency) : base(name, price, manufacturer, stock)
        {
            Frequency = frequency;
            Type = 0;
        }

        public int Frequency { get; } = 0;

    }
}
