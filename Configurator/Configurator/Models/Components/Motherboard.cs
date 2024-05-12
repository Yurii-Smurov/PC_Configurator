using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class Motherboard : PCComponent
    {
        public Motherboard()
        {
            Type = ComponentType.Motherboard;
        }

        public Motherboard(string form, string chipset, string socket, bool ddr4, bool ddr5, bool m2)
        {
            Form = form;
            Chipset = chipset;
            Socket = socket;
            DDR4 = ddr4;
            DDR5 = ddr5;
            M2 = m2;

            Type = ComponentType.Motherboard;
        }

        // Конструктор затычка

        public string Form {  get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public bool DDR4 { get; set; }
        public bool DDR5 { get; set; }
        public bool M2 { get; set; }
    }
}
