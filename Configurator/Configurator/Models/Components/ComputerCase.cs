namespace Configurator.Models.Components
{
    sealed class ComputerCase : PCComponent
    {
        public ComputerCase()
        {
            Type = ComponentType.ComputerCase;
        }

        public ComputerCase(string name, decimal price, string manufacturer, int stock, string form) : base(name, price, manufacturer, stock)
        {
            Form = form;

            Type = ComponentType.ComputerCase;
        }

        public string Form { get; set; } = String.Empty;
    }
}
