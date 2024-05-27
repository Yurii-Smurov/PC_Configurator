namespace Configurator.Models.Components
{
    class LiquidCoolingSystem : CoolingSystem
    {
        public LiquidCoolingSystem()
        {
            Type = ComponentType.LiquidCoolingSystem;
        }

        public LiquidCoolingSystem(string name, decimal price, string manufacturer, int stock, string socket, int speed, int tdpDIS, bool serviced) : base(name, price, manufacturer, stock, socket, speed, tdpDIS)
        {
            Type = ComponentType.LiquidCoolingSystem;
            Serviced = serviced;
        }
        public bool Serviced { get; set; }
    }
}
