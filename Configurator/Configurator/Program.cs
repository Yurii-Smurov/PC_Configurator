using Configurator;
using Configurator.Components;
using Configurator.PCBuider;

class Program
{
    static void Main()
    {
        var pc = new PCBuilder()
            .AddComponent(new Processor("intol", 2000, "sintol", 2000, 300000))
            .AddComponent(new Processor("intal", 2000, "sintol", 2000, 300000))
            .Build();

        pc.PrintComponents();
    }
}