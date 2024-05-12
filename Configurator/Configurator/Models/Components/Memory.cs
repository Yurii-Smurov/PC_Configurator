﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class Memory : PCComponent
    {
        public Memory()
        {
            Type = ComponentType.Memory;
        }

        public Memory(bool dDR4, bool dDR5, int freq, int volume)
        {
            DDR4 = dDR4;
            DDR5 = dDR5;
            Freq = freq;
            Volume = volume;

            Type = ComponentType.Memory;
        }



        // Конструктор затычка

        public bool DDR4 { get; set; }
        public bool DDR5 { get; set; }
        public int Freq { get; set; }
        public int Volume { get; set; }
    }
}
