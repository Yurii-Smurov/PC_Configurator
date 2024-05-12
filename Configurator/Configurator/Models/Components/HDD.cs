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

        public HDD(string form, string speed, string volume) : base(form, speed, volume)
        {
            Type = ComponentType.HDD;
        }
    }
}
