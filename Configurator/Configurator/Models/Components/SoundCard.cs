using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    sealed class SoundCard : PCComponent
    {
        public SoundCard()
        {
            Type = ComponentType.SoundCard;
        }

        public SoundCard(string form)
        {
            Form = form;

            Type = ComponentType.SoundCard;
        }

        // Конструктор затычка

        public string Form {  get; set; }
    }
}
