using Configurator.Views;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Reflection;

namespace ConfiguratorTests
{
    [TestFixture]
    public class ViewControllerTest
    {
        private ViewController _viewController;

        [SetUp]
        public void Setup()
        {
            _viewController = new ViewController();
        }

        [Test]
        public void ChangeState_WhenCalled_ShouldChangeCurrentView()
        {
            // Arrange
            var mockView = new Mock<IView>();

            // Act
            _viewController.ChangeState(mockView.Object);
            // Получение закрытого поля _currentView с использованием отражения
            var currentViewField = typeof(ViewController).GetField("_currentView", BindingFlags.NonPublic | BindingFlags.Instance);

            // Assert
            ClassicAssert.AreEqual(mockView.Object, currentViewField.GetValue(_viewController));
        }

        [Test]
        public void ShowCurrentView_WhenCalled_ShouldInvokeShowMethod()
        {
            // Arrange
            var mockView = new Mock<IView>();
            _viewController.ChangeState(mockView.Object);

            // Act
            _viewController.ShowCurrentView();

            // Assert
            mockView.Verify(v => v.Show(), Times.Once);
        }
    }
}
