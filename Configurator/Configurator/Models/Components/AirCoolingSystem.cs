using Configurator.Models.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    class AirCoolingSystem : CoolingSystem
    {
        public AirCoolingSystem()
        {
            Type = ComponentType.AirCoolingSystem;
        }

        public AirCoolingSystem(string name, decimal price, string manufacturer, int stock, string socket, int speed, int tdpDIS) : base(name, price, manufacturer, stock, socket, speed, tdpDIS)
        {
            Type = ComponentType.AirCoolingSystem;
        }
    }
}
