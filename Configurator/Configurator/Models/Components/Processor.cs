using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.Components
{
    /// <summary>
    /// Класс процессора
    /// </summary>
    sealed class Processor : PCComponent
    {
        public Processor()
        {
        }

        public Processor(string name, decimal price, string manufacturer, int stock, int frequency) : base(name, price, manufacturer, stock)
        {
            Frequency = frequency;
            Type = 0;
        }
        [Required]
        [Column(TypeName = "int")]
        public int Frequency { get; set; } = 0;

    }
}
