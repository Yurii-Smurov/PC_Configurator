using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    abstract class StorageDevice : PCComponent
    {
        public StorageDevice()
        {
            
        }

        protected StorageDevice(string name, decimal price, string manufacturer, int stock, string form, int speed, int volume) : base(name, price, manufacturer, stock)
        {
            Form = form;
            Speed = speed;
            Volume = volume;
        }

        // Конструктор затычка

        public string Form {  get; set; } = null!;
        public int Speed { get; set; }
        public int Volume { get; set; }
    }
}
