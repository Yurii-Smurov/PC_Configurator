using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class HDD : StorageDevice
    {
        public HDD()
        {
            Type = ComponentType.HDD;
        }

        public HDD(string name, decimal price, string manufacturer, int stock, string form, int speed, int volume, int rotation) : base(name, price, manufacturer, stock, form, speed, volume)
        {
            Rotation = rotation;
            Type = ComponentType.HDD;
        }
        public int Rotation { get; set; }
    }
}
