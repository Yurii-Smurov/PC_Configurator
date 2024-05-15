using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    class LiquidCoolingSystem : CoolingSystem
    {
        public LiquidCoolingSystem()
        {
            Type = ComponentType.LiquidCoolingSystem;
        }

        public LiquidCoolingSystem(string name, decimal price, string manufacturer, int stock, string socket, int speed, int tdpDIS) : base(name, price, manufacturer, stock, socket, speed, tdpDIS)
        {
            Type = ComponentType.LiquidCoolingSystem;
        }
    }
}
