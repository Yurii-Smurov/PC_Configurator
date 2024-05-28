using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ConfiguratorTests
{
    [TestFixture]
    class PCBuilderTest
    {
        [Test]
        public void AddComponent_AddsComponentToList()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            var component = new Processor();

            // Act
            pcBuilder.AddComponent(component);

            // Assert
            ClassicAssert.IsTrue(pcBuilder.Components.Contains(component));
        }

        [Test]
        public void RemoveComponent_RemovesComponentFromList()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            PCComponent component = new Processor();
            pcBuilder.AddComponent(component);

            // Act
            pcBuilder.RemoveComponent(ComponentType.Processor);

            // Assert
            ClassicAssert.IsFalse(pcBuilder.Components.Contains(component));
        }

        [Test]
        public void Build_ReturnsPCObjectIfValidConfiguration()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            pcBuilder.AddComponent(new Processor());
            pcBuilder.AddComponent(new GraphicsCard());
            pcBuilder.AddComponent(new Motherboard());
            pcBuilder.AddComponent(new PowerUnit());
            pcBuilder.AddComponent(new ComputerCase());
            pcBuilder.AddComponent(new Memory());
            pcBuilder.AddComponent(new SSD());
            pcBuilder.AddComponent(new AirCoolingSystem());

            // Act
            PC? pc = pcBuilder.Build();

            // Assert
            ClassicAssert.IsNotNull(pc);
        }

        [Test]
        public void Build_ReturnsNullIfInvalidConfiguration()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            // Adding only a processor, which is not a valid configuration
            pcBuilder.AddComponent(new Processor());

            // Act
            PC? pc = pcBuilder.Build();

            // Assert
            ClassicAssert.IsNull(pc);
        }

        [Test]
        public void HasComponentOfType_ReturnsTrueIfComponentTypeExists()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            PCComponent component = new GraphicsCard();
            pcBuilder.AddComponent(component);

            // Act
            bool result = pcBuilder.HasComponentOfType(ComponentType.GraphicsCard);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void HasComponentOfType_ReturnsFalseIfComponentTypeDoesNotExist()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();

            // Act
            bool result = pcBuilder.HasComponentOfType(ComponentType.Memory);

            // Assert
            ClassicAssert.IsFalse(result);
        }
    }
}
