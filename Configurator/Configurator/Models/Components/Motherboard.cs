using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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

        public Motherboard(string name, decimal price, string manufacturer, int stock, string form, string chipset, string socket, bool ddr4, bool ddr5, bool m2) : base(name, price, manufacturer, stock)
        {
            Form = form;
            Chipset = chipset;
            Socket = socket;
            DDR4 = ddr4;
            DDR5 = ddr5;
            M2 = m2;

            Type = ComponentType.Motherboard;
        }



        public string Form {  get; set; } = String.Empty;
        public string Chipset { get; set; } = String.Empty;
        public string Socket { get; set; } = String.Empty;
        public bool DDR4 { get; set; }
        public bool DDR5 { get; set; }
        public bool M2 { get; set; }
    }
}
