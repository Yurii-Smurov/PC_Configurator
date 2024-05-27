namespace Configurator.Models.Components
{
    sealed class SSD : StorageDevice
    {
        public SSD()
        {
            Type = ComponentType.SSD;
        }

        public SSD(string name, decimal price, string manufacturer, int stock, string form, int speed, int volume, bool nvme) : base(name, price, manufacturer, stock, form, speed, volume)
        {
            Nvme = nvme;
            Type = ComponentType.SSD;
        }
        public bool Nvme { get; set; }

    }
}
