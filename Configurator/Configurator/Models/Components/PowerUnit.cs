namespace Configurator.Models.Components
{
    sealed class PowerUnit : PCComponent
    {
        public PowerUnit()
        {
            Type = ComponentType.PowerUnit;
        }


        public PowerUnit(string name, decimal price, string manufacturer, int stock, string form) : base(name, price, manufacturer, stock)
        {
            Form = form;

            Type = ComponentType.PowerUnit;
        }

        public string Form {  get; set; } = String.Empty;

    }
}
