using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    abstract class CoolingSystem : PCComponent
    {
        // Конструктор затычка

        public CoolingSystem()
        {
            
        }

        protected CoolingSystem(string name, decimal price, string manufacturer, int stock, string socket, int speed, int tdpDIS) : base(name, price, manufacturer, stock)
        {
            Socket = socket;
            Speed = speed;
            TdpDIS = tdpDIS;
        }

        public string Socket { get; set; } = String.Empty;
        public int Speed { get; set; }
        public int TdpDIS { get; set; }
    }
    
}
