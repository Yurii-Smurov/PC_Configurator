namespace Configurator.Models.Components
{
    sealed class Memory : PCComponent
    {
        public Memory()
        {
            Type = ComponentType.Memory;
        }

        public Memory(string name, decimal price, string manufacturer, int stock, bool dDR4, bool dDR5, int freq, int volume) : base(name, price, manufacturer, stock)
        {
            DDR4 = dDR4;
            DDR5 = dDR5;
            Freq = freq;
            Volume = volume;

            Type = ComponentType.Memory;
        }



        public bool DDR4 { get; set; }
        public bool DDR5 { get; set; }
        public int Freq { get; set; }
        public int Volume { get; set; }
    }
}
