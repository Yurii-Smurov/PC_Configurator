using System;
using System.Collections.Generic;
using System.Linq;
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

        public CoolingSystem(string socket, int speed, int tdpDIS)
        {
            Socket = socket;
            Speed = speed;
            TdpDIS = tdpDIS;
        }

        public string Socket { get; set; }
        public int Speed { get; set; }
        public int TdpDIS { get; set; }
    }
    
}
