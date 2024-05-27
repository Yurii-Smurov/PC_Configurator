using Configurator.Models.Components;
using Configurator.Models.UserModels;
namespace Configurator.Models.PCBuider
{
    class PC
    {
        // Свойство - список подобранных комплектующих ПК
        public ICollection<PCComponent> Components { get; set; }
        public User User { get; set; } = null!;
        public int PCId { get; set; }

        /// <summary>
        /// Конструктор ПК
        /// </summary>
        /// <param name="components"></param>
        public PC(ICollection<PCComponent> components)
        {
            Components = components;
        }

        public PC()
        {
        }
    }
}
