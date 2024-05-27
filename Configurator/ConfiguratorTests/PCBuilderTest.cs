using Configurator.Models.Components;
using Configurator.Models.PCBuider;

namespace ConfiguratorTests
{
    [TestClass]
    class PCBuilderTest
    {
        [TestMethod]
        public void AddComponent_AddsComponentToList()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            var component = new Processor();

            // Act
            pcBuilder.AddComponent(component);

            // Assert
            Assert.IsTrue(pcBuilder.Components.Contains(component));
        }

        [TestMethod]
        public void RemoveComponent_RemovesComponentFromList()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            PCComponent component = new Processor();
            pcBuilder.AddComponent(component);

            // Act
            pcBuilder.RemoveComponent(ComponentType.Processor);

            // Assert
            Assert.IsFalse(pcBuilder.Components.Contains(component));
        }

        [TestMethod]
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
            Assert.IsNotNull(pc);
        }

        [TestMethod]
        public void Build_ReturnsNullIfInvalidConfiguration()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            // Adding only a processor, which is not a valid configuration
            pcBuilder.AddComponent(new Processor());

            // Act
            PC? pc = pcBuilder.Build();

            // Assert
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void HasComponentOfType_ReturnsTrueIfComponentTypeExists()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();
            PCComponent component = new GraphicsCard();
            pcBuilder.AddComponent(component);

            // Act
            bool result = pcBuilder.HasComponentOfType(ComponentType.GraphicsCard);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasComponentOfType_ReturnsFalseIfComponentTypeDoesNotExist()
        {
            // Arrange
            PCBuilder pcBuilder = new PCBuilder();

            // Act
            bool result = pcBuilder.HasComponentOfType(ComponentType.Memory);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
