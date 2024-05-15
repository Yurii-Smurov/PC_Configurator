using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class SSD : StorageDevice
    {
        public SSD()
        {
            Type = ComponentType.SSD;
        }

        public SSD(string name, decimal price, string manufacturer, int stock, string form, string speed, string volume) : base(name, price, manufacturer, stock, form, speed, volume)
        {
            Type = ComponentType.SSD;
        }
    }
}
