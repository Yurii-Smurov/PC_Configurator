using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class PowerUnit : PCComponent
    {
        public PowerUnit()
        {
            Type = ComponentType.PowerUnit;
        }

        public PowerUnit(string form)
        {
            Form = form;

            Type = ComponentType.PowerUnit;
        }

        // Конструктор затычка

        public string Form {  get; set; }

    }
}
