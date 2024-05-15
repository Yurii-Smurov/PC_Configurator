using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;

namespace Configurator.Models.Components
{
    /// <summary>
    /// Класс процессора
    /// </summary>
    sealed class Processor : PCComponent
    {
        public Processor()
        {
            Type = ComponentType.Processor;
        }

        public Processor(string name, decimal price, string manufacturer, int stock, string socket, bool dDR4, bool dDR5, bool m2, int tDP) : base(name, price, manufacturer, stock)
        {
            Socket = socket;
            DDR4 = dDR4;
            DDR5 = dDR5;
            M2 = m2;
            TDP = tDP;

            Type = ComponentType.Processor;
        }


        //[Required]
        //[Column(TypeName = "int")]
        public string Socket {  get; set; }
        public bool DDR4 { get; set; }
        public bool DDR5 { get; set; }
        public bool M2 {  get; set; }
        public int TDP { get; set; }

    }
}
