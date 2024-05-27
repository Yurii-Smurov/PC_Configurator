using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Configurator.Models.Components
{
    enum ComponentType
    {
        Processor,
        AirCoolingSystem,
        LiquidCoolingSystem,
        Motherboard,
        GraphicsCard,
        PowerUnit,
        HDD,
        SSD,
        ComputerCase,
        Memory,
        SoundCard
    }
    /// <summary>
    /// Шаблон для комплектующих
    /// </summary>
    abstract class PCComponent
    {
        protected PCComponent()
        {
        }

        // Базовый конструктор для всех компонентов
        protected PCComponent(string name, decimal price, string manufacturer, int stock)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
            Stock = stock;
        }
        // Базовые свойства для всех компонентов
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar (255)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0m;
        [Required]
        [Column(TypeName = "int")]
        public int Stock { get; set; } = 0;
        [Required]
        [Column(TypeName = "varchar (255)")]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public ComponentType Type { get; protected set; }
    }
}
